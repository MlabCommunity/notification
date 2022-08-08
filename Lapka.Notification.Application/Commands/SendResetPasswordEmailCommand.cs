using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SendResetPasswordEmailCommand(string Email, string Token, Guid Id) : ICommand;