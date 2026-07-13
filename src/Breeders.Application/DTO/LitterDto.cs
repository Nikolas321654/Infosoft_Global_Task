using Breeders.Domain.Enums;

namespace Breeders.Application.DTOs;

public class LitterDto
{
    public Guid Id { get; set; }
    public LitterStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}