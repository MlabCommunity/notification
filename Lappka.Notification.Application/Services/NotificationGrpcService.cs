using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Identity;

namespace Lappka.Notification.Application.Services;

public class NotificationGrpcService : NotificationService.NotificationServiceBase
{
    public override async Task<Empty> RestartPassword(RestartPasswordRequest request, ServerCallContext context)
    {
        Console.WriteLine($"User with email: {request.Email} requested password reset");

        return new();
    }
}