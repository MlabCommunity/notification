using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveEmailDataConfirmEmailCommand(string Email, string Token) : ICommand;