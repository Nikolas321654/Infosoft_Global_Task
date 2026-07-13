using Breeders.Application.Interfaces;

namespace Breeders.Infrastructure.Services;

public class ConsoleNotificationService : INotificationService
{
    public Task SendEmailAsync(Guid breederId, string subject, string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"[EMAIL SENT to Breeder {breederId}]");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Body: {message}");
        Console.ResetColor();

        return Task.CompletedTask;
    }
}