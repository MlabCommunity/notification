using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveEmailData_ResetEmailCommand(string Email, string Token, Guid Id) : ICommand;