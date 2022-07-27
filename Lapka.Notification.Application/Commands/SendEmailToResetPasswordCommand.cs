using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SendEmailToResetPasswordCommand(string Email, string Token, Guid Id) : ICommand;