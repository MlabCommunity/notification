using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendEmailToResetEmailCommandHandler : ICommandHandler<SendEmailToResetEmailCommand>
{
    public Task HandleAsync(SendEmailToResetEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}