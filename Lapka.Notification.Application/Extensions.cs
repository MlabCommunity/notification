using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lapka.Notification.Application.RequestStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Notification.Application;

public static class Extensions
{
    public static IServiceProvider AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRequestStorage, RequestStorage.RequestStorage>();

        var builder = services.AddConvey()
            .AddCommandHandlers()
            .AddInMemoryCommandDispatcher()
            .AddQueryHandlers()
            .AddInMemoryQueryDispatcher();

        return builder.Build();
    }
}
