using Breeders.Domain.Entities;

namespace Breeders.Application.Interfaces;

public interface IAuditLogRepository
{
    void Add(AuditLog auditLog);
}