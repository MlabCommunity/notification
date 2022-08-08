using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands;

public record SendChangeEmailCommand(Guid NotificationId, string Email, string ConfirmationToken) : ICommand;
