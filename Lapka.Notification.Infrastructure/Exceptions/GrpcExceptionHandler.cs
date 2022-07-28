using Grpc.Core;
using Grpc.Core.Interceptors;
using Lapka.Notification.Application.Exceptions;
using Microsoft.Extensions.Logging;

namespace Lapka.Notification.Infrastructure.Exceptions;

public sealed class GrpcExceptionHandler : Interceptor
{
    private readonly ILogger<GrpcExceptionHandler> _logger;

    public GrpcExceptionHandler(ILogger<GrpcExceptionHandler> logger)
    {
        _logger = logger;
    }
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await base.UnaryServerHandler(request, context, continuation);
        }
        catch (ProjectGrpcException gex)
        {
            _logger.LogError(gex, gex.Message);

            var concreteResponse = Activator.CreateInstance<TResponse>();

            var code = gex.StatusCode;
            var message = gex.Message;
            concreteResponse?.GetType().GetProperty(nameof(code))?.SetValue(concreteResponse, code);
            concreteResponse?.GetType().GetProperty(nameof(message))?.SetValue(concreteResponse, message);

            context.Status = gex.Status;
            return concreteResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var concreteResponse = Activator.CreateInstance<TResponse>();

            var message = ex.Message;
            concreteResponse?.GetType().GetProperty(nameof(message))?.SetValue(concreteResponse, message);

            context.Status = new Status(statusCode: StatusCode.Internal, ex.Message);
            return concreteResponse;
        }
    }
}