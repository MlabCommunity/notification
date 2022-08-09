using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace Lappka.Notification.Application;

public static class Extensions
{
    public static IServiceProvider AddApplication(this IServiceCollection services)
    {
        var builder = services.AddConvey()
            .AddRabbitMq()
            .AddCommandHandlers()
            .AddInMemoryCommandDispatcher()
            .AddQueryHandlers()
            .AddInMemoryQueryDispatcher()
            .AddEventHandlers()
            .AddServiceBusEventDispatcher();
        
        return builder.Build();
    }
}