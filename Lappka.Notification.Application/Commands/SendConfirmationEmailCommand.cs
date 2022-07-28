using Convey.CQRS.Commands;

namespace Scheme.Application.Commands;

public record SendConfirmationEmailCommand : ICommand
{
    public Guid NotificationId { get; init; }
    public string Email { get; init; }
    public string ConfirmationToken { get; init; }
}