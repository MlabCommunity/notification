using Grpc.Core;

namespace Lapka.Notification.Application.Exceptions.GrpcExceptions;

public class UserNotFoundException : ProjectGrpcException
{
    public UserNotFoundException(Exception inner = null)
        : base(new Status(statusCode:StatusCode.NotFound, "User not found in notification service database."), "Not found.", inner) { }
}