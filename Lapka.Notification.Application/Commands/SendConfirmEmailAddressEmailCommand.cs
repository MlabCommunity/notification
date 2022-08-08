using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SendConfirmEmailAddressEmailCommand(string Email, string Token, Guid Id) : ICommand;