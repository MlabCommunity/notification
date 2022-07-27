using Convey.CQRS.Commands;
using Lapka.Notification.Application.Commands;

namespace Lapka.Notification.Application.CommandHandlers;

public class SaveEmailDataResetEmailCommandHandler : ICommandHandler<SaveEmailDataResetEmailCommand>
{
    public Task HandleAsync(SaveEmailDataResetEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}