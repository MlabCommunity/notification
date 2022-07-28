using Convey.CQRS.Commands;

namespace Lapka.Notification.Application.Commands;

public record SendEmailToResetEmailCommand(string Email, string Token, Guid Id) : ICommand;