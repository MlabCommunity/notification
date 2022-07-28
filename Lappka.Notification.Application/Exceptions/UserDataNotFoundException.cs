using Grpc.Core;

namespace Scheme.Application.Exceptions;

public class UserDataNotFoundException : ProjectGrpcException
{
    public UserDataNotFoundException( StatusCode errorCode = StatusCode.NotFound) : base("User Data not found", errorCode)
    {
    }
}