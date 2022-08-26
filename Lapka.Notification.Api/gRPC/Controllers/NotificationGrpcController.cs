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

        var saveDataCommand = new SaveResetPasswordDataCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(saveDataCommand);

        var sendEmailCommand = new SendResetPasswordEmailCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(sendEmailCommand);

        return new();
    }

    public override async Task<Empty> ResetEmail(ResetEmailRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveDataCommand = new SaveResetEmailAddressDataCommand(request.Email, request.Token, request.UserId, notificationId);
        await _commandDispatcher.SendAsync(saveDataCommand);

        var sendEmailCommand = new SendResetEmailAddressEmailCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(sendEmailCommand);

        return new();
    }

    public override async Task<Empty> ConfirmEmail(ConfirmEmailRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveDataCommand = new SaveConfirmEmailAddressDataCommand(request.Email, request.Token, notificationId,
            request.Username, request.Firstname, request.Lastname, request.Userid);
        await _commandDispatcher.SendAsync(saveDataCommand);

        var sendEmailCommand = new SendConfirmEmailAddressEmailCommand(request.Email, request.Token, notificationId);
        await _commandDispatcher.SendAsync(sendEmailCommand);

        return new();
    }
}