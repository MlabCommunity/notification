using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands;

public record SaveResetPasswordCommand(Guid NotificationId, string Email, string ConfirmationToken) : ICommand;
