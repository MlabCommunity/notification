

using Grpc.Core;

namespace Scheme.Application.Exceptions;

public class NotificationHistoryNotFound : ProjectGrpcException
{
    public NotificationHistoryNotFound(StatusCode errorCode = StatusCode.NotFound) : base("Notification history not found", errorCode)
    {
    }
}