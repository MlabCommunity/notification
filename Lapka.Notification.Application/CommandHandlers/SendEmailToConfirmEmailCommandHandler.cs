using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;

namespace Lapka.Notification.Application.CommandHandlers;

public class SendEmailToConfirmEmailCommandHandler : ICommandHandler<SendEmailToConfirmEmailCommand>
{
    public Task HandleAsync(SendEmailToConfirmEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}