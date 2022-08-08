using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SendResetEmailAddressEmailCommand(string Email, string Token, Guid Id) : ICommand;