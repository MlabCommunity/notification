using Grpc.Core;

namespace Lapka.Notification.Application.Exceptions;

public class ProjectGrpcException : RpcException
{
    public Exception ProjectInnerException { get; }

    public ProjectGrpcException(Status status, string message, Exception innerException = null) 
        : base(status, message)
    {
        ProjectInnerException = innerException;
    }
}