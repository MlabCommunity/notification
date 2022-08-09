using Grpc.Core;

namespace Lappka.Notification.Application.Exceptions;

public class ProjectGrpcException : RpcException
{
    protected ProjectGrpcException(Status status, string message) : base(status, message)
    {
    }
    
}