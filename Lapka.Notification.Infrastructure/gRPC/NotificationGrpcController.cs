using Convey.CQRS.Commands;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Lapka.Notification.Application.Commands;
using Lapka.NotificationHistory.Infrastructure;

namespace Lapka.Notification.Infrastructure.gRPC;

public class NotificationGrpcController : NotificationService.NotificationServiceBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public NotificationGrpcController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    public override async Task<Empty> ResetPassword(ResetPasswordRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveDataCommand = new SaveEmailDataResetPasswordCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(saveDataCommand);

        var sendEmailCommand = new SendEmailToResetPasswordCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(sendEmailCommand);

        return new();
    }

    public override async Task<Empty> ResetEmail(ResetEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Reset maila {request.Email}, tokenem: {request.Token}");

        return new();
    }

    public override async Task<Empty> ConfirmEmail(ConfirmEmailRequest request, ServerCallContext context)
    {
        Console.WriteLine($"Potwierdzenie maila {request.Email}, tokenem: {request.Token}");

        return new();
    }
}