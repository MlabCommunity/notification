using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveResetEmailAddressDataCommand(string Email, string Token, string userId, Guid Id) : ICommand;