namespace Breeders.Application.Interfaces;

public interface INotificationService
{
    Task SendEmailAsync(Guid breederId, string subject, string message);
}