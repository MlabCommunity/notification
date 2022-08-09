using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands;

public record SendResetPasswordCommand(Guid NotificationId, string Email, string ConfirmationToken) : ICommand;
