using Lappka.Notification.Core.Repositories;
using Lappka.Notification.Infrastructure.Database.Contexts;
using Lappka.Notification.Infrastructure.Database.Postgres;
using Lappka.Notification.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lappka.Notification.Infrastructure.Database;

public static class Extensions
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INotificationHistoryRepository, PostgresNotificationHistoryRepository>();
        services.AddScoped<IUserDataRepository, PostgresUserDataRepository>();
        
        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<NotificationDbContext>(ctx =>
            ctx.UseNpgsql(options.ConnectionString));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddScoped<INotificationDbContext, NotificationDbContext>();

        return services;
    }
}