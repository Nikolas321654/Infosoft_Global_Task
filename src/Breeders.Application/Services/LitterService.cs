using Breeders.Application.DTOs;
using Breeders.Application.Exceptions;
using Breeders.Application.Interfaces;
using Breeders.Domain.Entities;
using Breeders.Domain.Enums;

namespace Breeders.Application.Services;

public class LitterService(
    ILitterRepository litterRepository,
    IBreederBenefitRepository benefitRepository,
    IAuditLogRepository auditLogRepository,
    IUnitOfWork unitOfWork,
    INotificationService notificationService)
    : ILitterService
{
    public async Task PublishLitterAsync(Guid litterId, Guid breederId, CancellationToken cancellationToken = default)
    {
        var litter = await litterRepository.GetByIdAsync(litterId, cancellationToken);
        if (litter == null)
            throw new NotFoundException($"Litter with ID {litterId} was not found.");

        if (litter.BreederId != breederId)
            throw new DomainException("You can only publish your own litters.");

        if (litter.Status != LitterStatus.Approved)
            throw new DomainException($"Litter must be in '{LitterStatus.Approved}' status to be published.");

        var benefit = await benefitRepository.GetByBreederIdAsync(breederId, cancellationToken);
        if (benefit == null)
            throw new NotFoundException("Breeder benefits configuration not found.");

        if (benefit.UsedCount >= benefit.FreeLimit)
        {
            auditLogRepository.Add(new AuditLog
            {
                Id = Guid.NewGuid(),
                EntityId = litterId,
                Action = "Publish attempt failed - limits exceeded",
                CreatedAt = DateTime.UtcNow
            });
            await unitOfWork.SaveChangesAsync(cancellationToken);

            throw new DomainException("Publish limit exceeded. You have no free publications left.");
        }

        benefit.UsedCount += 1;
        litter.Status = LitterStatus.Published;

        auditLogRepository.Add(new AuditLog
        {
            Id = Guid.NewGuid(),
            EntityId = litterId,
            Action = "Published for free",
            CreatedAt = DateTime.UtcNow
        });

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await notificationService.SendEmailAsync(
            breederId,
            "Litter Published",
            $"Your litter {litterId} has been successfully published for free.");
    }

    public async Task<PaginatedList<LitterDto>> GetLittersAsync(
        Guid breederId,
        LitterStatus? status,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await litterRepository.GetPagedByBreederAsync(
            breederId, status, pageNumber, pageSize, cancellationToken);

        var dtos = items.Select(l => new LitterDto
        {
            Id = l.Id,
            Status = l.Status,
            CreatedAt = l.CreatedAt
        });

        return new PaginatedList<LitterDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }
}