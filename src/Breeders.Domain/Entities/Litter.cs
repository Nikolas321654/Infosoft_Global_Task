using Breeders.Domain.Enums;

namespace Breeders.Domain.Entities;

public class Litter
{
    public Guid Id { get; set; }
    public Guid BreederId { get; set; }
    public LitterStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}