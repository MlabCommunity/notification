using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scheme.Infrastructure.Database;
using Scheme.Infrastructure.Services;

namespace Scheme.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<AppInitializer>();
        services.AddPostgres(configuration);

        return services;
    }
    
    public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
    {

        return app;
    }
}