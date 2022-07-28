using Grpc.Core;

namespace Scheme.Application.Exceptions;

public class ProjectGrpcException : RpcException
{
    protected ProjectGrpcException(string message,StatusCode errorCode = StatusCode.Unknown) : base(new Status(errorCode,errorCode.ToString()),message)
    {
    }

}
