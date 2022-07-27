using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveEmailDataResetPasswordCommand(string Email, string Token, Guid Id) : ICommand;