using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Lappka.Notification.Application.Services;

public class NotificationGrpcController : NotificationController.NotificationControllerBase
{
    public override async Task<Empty> ConfirmEmail(ConfirmEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"ConfirmEmail called,Email {request.Email}, token {request.Token}");
        return new();
    }

    public override async Task<Empty> ChangeEmail(ChangeEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"ResetEmail called,Email {request.Email}, token {request.Token}");
        return new();
    }

    public override async Task<Empty> ResetPassword(ResetPasswordRequest request, ServerCallContext context)
    {
        Console.WriteLine($"RestartPassword called,Email {request.Email}, token {request.Token}");
        return new();
    }
}