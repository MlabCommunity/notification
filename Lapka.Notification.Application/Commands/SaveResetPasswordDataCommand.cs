using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveResetPasswordDataCommand(string Email, string Token, Guid Id) : ICommand;