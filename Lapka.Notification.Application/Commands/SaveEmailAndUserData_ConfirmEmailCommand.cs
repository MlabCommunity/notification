using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SaveEmailAndUserData_ConfirmEmailCommand(string Email, string Token, Guid Id, string Username, string FirstName, string LastName, Guid UserId) : ICommand;