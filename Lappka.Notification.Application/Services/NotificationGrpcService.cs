using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Lappka.Notification.Application.Services;

public class NotificationGrpcService : NotificationService.NotificationServiceBase
{
    public override async Task<Empty> ConfirmEmail(ConfirmEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"ConfirmEmail called,Email {request.Email}, token {request.Token}");
        return new();
    }

    public override async Task<Empty> ResetEmail(ResetEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"ResetEmail called,Email {request.Email}, token {request.Token}");
        return new();
    }

    public override async Task<Empty> RestartPassword(ResetPasswordRequest request, ServerCallContext context)
    {
        Console.WriteLine($"RestartPassword called,Email {request.Email}, token {request.Token}");
        return new();
    }
}