

using System.Net;
using Grpc.Core;

namespace Lappka.Notification.Application.Exceptions;

public class NotificationHistoryNotFound : ProjectGrpcException
{
    public NotificationHistoryNotFound() : base(new Status(StatusCode.NotFound,"Notification history not found"),"Not found")
    {
    }

}