using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveEmailData_ResetPasswordCommand(string Email, string Token, Guid Id) : ICommand;