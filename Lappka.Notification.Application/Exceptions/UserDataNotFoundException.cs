using System.Net;
using Grpc.Core;

namespace Lappka.Notification.Application.Exceptions;

public class UserDataNotFoundException : ProjectGrpcException
{
    public UserDataNotFoundException() : base(new Status(StatusCode.NotFound,"User data not found"),"not found")
    {
    }
}