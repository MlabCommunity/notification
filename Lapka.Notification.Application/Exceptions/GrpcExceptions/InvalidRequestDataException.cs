using Grpc.Core;

namespace Lapka.Notification.Application.Exceptions.GrpcExceptions;

public class InvalidRequestDataException : ProjectGrpcException
{
    public InvalidRequestDataException(Exception inner = null) 
        : base(new Status(statusCode: StatusCode.InvalidArgument, "Invalid request data."), $"Invalid data.", inner ) { }
}