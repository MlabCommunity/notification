using Lapka.Notification.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lapka.Notification.Infrastructure.Exceptions;

public sealed class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ProjectException pex)
        {
            _logger.LogError(pex, pex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "server error");
        }
    }
}
