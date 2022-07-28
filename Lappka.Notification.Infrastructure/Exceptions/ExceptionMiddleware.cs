using System.Text.Json;
using Lappka.Notification.Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Lappka.Notification.Infrastructure.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ProjectException ex)
        {
            context.Response.StatusCode = ex.ErrorCode;
            context.Response.Headers.Add("content-type", "application/json");

            var json = JsonSerializer.Serialize(
                new { ErrorCode = ex.ErrorCode, ex.Message, Errors = ex.ExceptionData });
            await context.Response.WriteAsync(json);
        }
    }
}