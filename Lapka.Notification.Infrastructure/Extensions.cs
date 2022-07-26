using Lapka.Notification.Infrastructure.DataBase;
using Lapka.Notification.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lapka.Notification.Infrastructure;

public static class Extensions
{
    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpc();

        services.AddHostedService<DbMigrator>();
        services.AddScoped<ExceptionMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseInfrastucture(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}
