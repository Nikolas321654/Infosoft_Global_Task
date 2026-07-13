using Breeders.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Breeders.Infrastructure.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.EntityId)
            .IsRequired();
            
        builder.Property(x => x.Action)
            .HasMaxLength(255)
            .IsRequired();
            
        builder.Property(x => x.CreatedAt)
            .IsRequired();
    }
}