using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SendEmailToConfirmEmailCommand(string Email, string Token) : ICommand;