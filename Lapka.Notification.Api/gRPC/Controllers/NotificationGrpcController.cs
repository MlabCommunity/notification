using Convey.CQRS.Commands;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Lapka.Notification.Application.Commands;

namespace Lapka.Notification.Api.gRPC.Controllers;

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

        var saveDataCommand = new SaveEmailData_ResetPasswordCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(saveDataCommand);

        var sendEmailCommand = new SendEmailToResetPasswordCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(sendEmailCommand);

        return new();
    }

    public override async Task<Empty> ResetEmail(ResetEmailRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveDataCommand = new SaveEmailData_ResetEmailCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(saveDataCommand);

        var sendEmailCommand = new SendEmailToResetEmailCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(sendEmailCommand);

        return new();
    }

    public override async Task<Empty> ConfirmEmail(ConfirmEmailRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveDataCommand = new SaveEmailAndUserData_ConfirmEmailCommand(request.Email, request.Token, notificationId,
            request.Username, request.Firstname, request.Lastname, Guid.Parse((ReadOnlySpan<char>)request.Userid));
        await _commandDispatcher.SendAsync(saveDataCommand);

        var sendEmailCommand = new SendEmailToConfirmEmailCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(sendEmailCommand);

        return new();
    }
}