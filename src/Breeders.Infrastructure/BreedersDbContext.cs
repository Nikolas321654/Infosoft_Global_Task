using System.Reflection;
using Breeders.Domain.Entities;
using Breeders.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Breeders.Infrastructure;

public class BreedersDbContext(DbContextOptions<BreedersDbContext> options) : DbContext(options)
{
    public DbSet<Litter> Litters => Set<Litter>();
    public DbSet<BreederBenefit> BreederBenefits => Set<BreederBenefit>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var testBreederId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        modelBuilder.Entity<BreederBenefit>().HasData(
            new BreederBenefit
            {
                BreederId = testBreederId,
                FreeLimit = 3,
                UsedCount = 0
            }
        );

        modelBuilder.Entity<Litter>().HasData(
            new Litter
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                BreederId = testBreederId,
                Status = LitterStatus.Approved,
                CreatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new Litter
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                BreederId = testBreederId,
                Status = LitterStatus.Draft,
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}