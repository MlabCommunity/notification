using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands;

public record SaveChangeEmailCommand(Guid NotificationId, string Email, string ConfirmationToken) : ICommand;
