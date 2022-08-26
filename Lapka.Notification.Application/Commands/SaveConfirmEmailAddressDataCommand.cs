using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveConfirmEmailAddressDataCommand(string Email, string Token, Guid Id, string Username, string FirstName, string LastName, string UserId) : ICommand;