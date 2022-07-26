using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace Lapka.Notification.Infrastructure.Services;

public class NotificationGrpcService : NotificationService.NotificationServiceBase
{
    public override Task<Empty> RestartPassword(RestartPasswordRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Reset hasła dla emaila {request.Email}, tokenem: {request.Token}");
        return Task.FromResult<Empty>(null);
    }
}

