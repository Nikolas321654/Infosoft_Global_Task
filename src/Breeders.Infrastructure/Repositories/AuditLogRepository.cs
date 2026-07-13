using Breeders.Application.Interfaces;
using Breeders.Domain.Entities;

namespace Breeders.Infrastructure.Repositories;

public class AuditLogRepository(BreedersDbContext context) : IAuditLogRepository
{
    public void Add(AuditLog auditLog)
    {
        context.AuditLogs.Add(auditLog);
    }
}