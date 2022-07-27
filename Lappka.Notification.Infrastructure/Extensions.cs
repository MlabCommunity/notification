using Lappka.Notification.Core.Services;
using Lappka.Notification.Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lappka.Notification.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<AppInitializer>();
        services.AddPostgres(configuration);

        return services;
    }
}