using Breeders.Application.DTOs;
using Breeders.Domain.Enums;

namespace Breeders.Application.Interfaces;

public interface ILitterService
{
    Task PublishLitterAsync(Guid litterId, Guid breederId, CancellationToken cancellationToken = default);
    
    Task<PaginatedList<LitterDto>> GetLittersAsync(
        Guid breederId, 
        LitterStatus? status, 
        int pageNumber, 
        int pageSize, 
        CancellationToken cancellationToken = default);
}