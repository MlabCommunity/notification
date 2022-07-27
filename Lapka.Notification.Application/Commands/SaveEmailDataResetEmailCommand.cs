using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveEmailDataResetEmailCommand(string Email, string Token) : ICommand;