using Breeders.Application.Interfaces;
using Breeders.Domain.Entities;
using Breeders.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Breeders.Infrastructure.Repositories;

public class LitterRepository(BreedersDbContext context) : ILitterRepository
{
    public async Task<Litter?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Litters
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);
    }

    public async Task<(IEnumerable<Litter> Items, int TotalCount)> GetPagedByBreederAsync(
        Guid breederId,
        LitterStatus? status,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var query = context.Litters
            .AsNoTracking()
            .Where(l => l.BreederId == breederId);

        if (status.HasValue)
        {
            query = query.Where(l => l.Status == status.Value);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderByDescending(l => l.CreatedAt)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, totalCount);
    }
}