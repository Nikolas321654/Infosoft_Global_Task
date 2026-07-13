using Breeders.Domain.Entities;

namespace Breeders.Application.Interfaces;

public interface IBreederBenefitRepository
{
    Task<BreederBenefit?> GetByBreederIdAsync(Guid breederId, CancellationToken cancellationToken = default);
}