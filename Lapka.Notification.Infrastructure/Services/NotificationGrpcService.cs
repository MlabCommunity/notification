using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Lapka.Notification.Infrastructure.Services;

public class NotificationGrpcService : NotificationService.NotificationServiceBase
{
    public override Task<Empty> ResetPassword(ResetPasswordRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Reset hasła dla emaila {request.Email}, tokenem: {request.Token}");
        return Task.FromResult(new Empty());
    }

    public override Task<Empty> ResetEmail(ResetEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Reset maila {request.Email}, tokenem: {request.Token}");
        return Task.FromResult(new Empty());
    }

    public override Task<Empty> ConfirmEmail(ConfirmEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Potwierdzenie maila {request.Email}, tokenem: {request.Token}");
        return Task.FromResult(new Empty());
    }
}