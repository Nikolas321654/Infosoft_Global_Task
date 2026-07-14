using Breeders.Application.Interfaces;
using Breeders.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Breeders.Infrastructure.Repositories;

public class BreederBenefitRepository(BreedersDbContext context) : IBreederBenefitRepository
{
    public async Task<BreederBenefit?> GetByBreederIdAsync(Guid breederId,
        CancellationToken cancellationToken = default)
    {
        return await context.BreederBenefits
            .FirstOrDefaultAsync(b => b.BreederId == breederId, cancellationToken);
    }
}