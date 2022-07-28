using Grpc.Core;

namespace Lapka.Notification.Application.Exceptions.GGrpcExceptions;

public class UserNotFoundException : ProjectGrpcException
{
    public UserNotFoundException(Exception inner = null)
        : base(new Status(statusCode:StatusCode.NotFound, "Not found."), $"User not found in local database.", inner) { }
}