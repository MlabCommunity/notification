using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands.Handlers;

public class SaveEmailCommandHandler : ICommandHandler<SaveEmailCommand>
{
    public async Task HandleAsync(SaveEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        await Task.CompletedTask;
    }
}