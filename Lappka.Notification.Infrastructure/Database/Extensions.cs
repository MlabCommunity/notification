using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scheme.Core.Repositories;
using Scheme.Infrastructure.Database.Contexts;
using Scheme.Infrastructure.Database.Postgres;
using Scheme.Infrastructure.Options;

namespace Scheme.Infrastructure.Database;

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