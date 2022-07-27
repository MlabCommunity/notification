using Convey.CQRS.Commands;

namespace Lappka.Notification.Application.Commands.Handlers;

public class SendEmailCommandHandler : ICommandHandler<SendEmailCommand>
{
    public async Task HandleAsync(SendEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
    {
        Console.Write();
        await Task.CompletedTask; //TODO: Send email
    }
}