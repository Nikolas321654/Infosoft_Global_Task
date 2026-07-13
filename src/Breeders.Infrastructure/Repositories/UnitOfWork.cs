using Breeders.Application.Interfaces;

namespace Breeders.Infrastructure.Repositories;

public class UnitOfWork(BreedersDbContext context) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}