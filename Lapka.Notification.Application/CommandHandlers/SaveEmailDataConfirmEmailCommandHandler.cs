using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;

namespace Lapka.Notification.Application.CommandHandlers;

public class SaveEmailDataConfirmEmailCommandHandler : ICommandHandler<SaveEmailDataConfirmEmailCommand>
{
    public Task HandleAsync(SaveEmailDataConfirmEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}