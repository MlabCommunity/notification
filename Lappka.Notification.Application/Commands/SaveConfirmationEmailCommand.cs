using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands;

public record SaveEmailCommand(string Email,string ConfirmationToken) : ICommand;