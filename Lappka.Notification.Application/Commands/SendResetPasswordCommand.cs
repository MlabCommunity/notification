using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands;

public record SendResetPasswordCommand : ICommand
{
    public Guid NotificationId { get; init; }
    public string Email { get; init; }
    public string ConfirmationToken { get; init; }
}