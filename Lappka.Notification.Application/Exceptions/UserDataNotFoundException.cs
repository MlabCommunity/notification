using System.Net;
using Grpc.Core;

namespace Lappka.Notification.Application.Exceptions;

public class UserDataNotFoundException : ProjectGrpcException
{
    public UserDataNotFoundException(HttpStatusCode status = HttpStatusCode.NotFound) : base(new Status(StatusCode.NotFound,"User data not found"),"not found")
    {
    }
}