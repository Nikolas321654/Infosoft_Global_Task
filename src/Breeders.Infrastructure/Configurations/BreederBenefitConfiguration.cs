using Breeders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Breeders.Infrastructure.Configurations;

public class BreederBenefitConfiguration : IEntityTypeConfiguration<BreederBenefit>
{
    public void Configure(EntityTypeBuilder<BreederBenefit> builder)
    {
        builder.HasKey(x => x.BreederId);
        
        builder.Property(x => x.FreeLimit)
            .IsRequired();
            
        builder.Property(x => x.UsedCount)
            .IsRequired();
    }
}