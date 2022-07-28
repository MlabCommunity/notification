using Grpc.Core;

namespace Lapka.Notification.Application.Exceptions;

public class ProjectGrpcException : RpcException
{
    private Exception _innException;

    public ProjectGrpcException(Status status, String message, Exception innException = null) : base(status, message)
    {
        _innException = innException;
    }
}