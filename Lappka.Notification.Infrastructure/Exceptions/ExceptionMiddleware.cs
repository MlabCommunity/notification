using System.Net;
using System.Text.Json;
using Grpc.Core;
using Lappka.Notification.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lappka.Notification.Infrastructure.Exceptions;

internal sealed class ExceptionMiddleware : IMiddleware
{
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ProjectGrpcException ex) when (ex.StatusCode == StatusCode.NotFound)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.Headers.Add("content-type", "application/json");

            var json = JsonSerializer.Serialize(
                new {HttpStatusCode.NotFound, ex.Status.Detail });
            await context.Response.WriteAsync(json);
        }
        catch (ProjectGrpcException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.Headers.Add("content-type", "application/json");

            var json = JsonSerializer.Serialize(
                new {HttpStatusCode.InternalServerError, ex.Status.Detail });
            await context.Response.WriteAsync(json);
        }
    }
}