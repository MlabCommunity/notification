using Lappka.Notification.Core.Repositories;
using Lappka.Notification.Infrastructure.Database;
using Lappka.Notification.Infrastructure.Database.Postgres;
using Lappka.Notification.Infrastructure.Exceptions;
using Lappka.Notification.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
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
    
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();
        return services;
    }

    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}