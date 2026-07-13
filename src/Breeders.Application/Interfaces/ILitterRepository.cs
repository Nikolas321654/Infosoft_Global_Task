using Breeders.Domain.Entities;
using Breeders.Domain.Enums;

namespace Breeders.Application.Interfaces;

public interface ILitterRepository
{
    Task<Litter?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<(IEnumerable<Litter> Items, int TotalCount)> GetPagedByBreederAsync(
        Guid breederId, 
        LitterStatus? status, 
        int pageNumber, 
        int pageSize, 
        CancellationToken cancellationToken = default);
}