using Grpc.Core;

namespace Lapka.Notification.Application.Exceptions.GGrpcExceptions;

public class InvalidRequestDataException : ProjectGrpcException
{
    public InvalidRequestDataException(Exception inner = null) 
        : base(new Status(statusCode: StatusCode.InvalidArgument, "Invalid request data."), $"Invalid request data.", inner ) { }
}