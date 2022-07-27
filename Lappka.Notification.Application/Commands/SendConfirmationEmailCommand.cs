using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands;

public record SendEmailCommand(string Email,string ConfirmationToken) : ICommand;
