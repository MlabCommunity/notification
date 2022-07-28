using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Lappka.Notification.Application.Commands;
using Lappka.Notification.Application.Commands.Handlers;


namespace Lappka.Notification.Api.GrpcControllers;

public class NotificationGrpcController : NotificationController.NotificationControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;

    public NotificationGrpcController(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }


    public override async Task<Empty> ConfirmEmail(ConfirmEmailRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveCommand = new SaveConfirmationEmailCommand
        {
            NotificationId = notificationId,
            Email = request.Email,
            ConfirmationToken = request.Token
        };

        await _commandDispatcher.SendAsync(saveCommand);

        var sendCommand = new SendConfirmationEmailCommand
        {
            NotificationId = notificationId,
            Email = request.Email,
            ConfirmationToken = request.Token
        };

        await _commandDispatcher.SendAsync(sendCommand);

        Console.WriteLine($"ConfirmEmail called,Email {request.Email}, token {request.Token}");
        return new();
    }

    public override async Task<Empty> ChangeEmail(ChangeEmailRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveCommand = new SaveChangeEmailCommand()
        {
            NotificationId = notificationId,
            Email = request.Email,
            ConfirmationToken = request.Token
        };

        await _commandDispatcher.SendAsync(saveCommand);

        var sendCommand = new SendChangeEmailCommand
        {
            NotificationId = notificationId,
            Email = request.Email,
            ConfirmationToken = request.Token
        };

        await _commandDispatcher.SendAsync(sendCommand);
        Console.WriteLine($"ResetEmail called,Email {request.Email}, token {request.Token}");
        return new();
    }

    public override async Task<Empty> ResetPassword(ResetPasswordRequest request, ServerCallContext context)
    {
        var notificationId = Guid.NewGuid();

        var saveCommand = new SendResetPasswordCommand
        {
            NotificationId = notificationId,
            Email = request.Email,
            ConfirmationToken = request.Token
        };

        await _commandDispatcher.SendAsync(saveCommand);

        var sendCommand = new SendResetPasswordCommand
        {
            NotificationId = notificationId,
            Email = request.Email,
            ConfirmationToken = request.Token
        };

        await _commandDispatcher.SendAsync(sendCommand);
        Console.WriteLine($"RestartPassword called,Email {request.Email}, token {request.Token}");
        return new();
    }
}