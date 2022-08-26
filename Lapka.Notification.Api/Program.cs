using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Lapka.Notification.Api.gRPC.Controllers;
using Lapka.Notification.Application;
using Lapka.Notification.Application.RabbitEvents;
using Lapka.Notification.Infrastructure;
using Lapka.Notification.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddGrpc();
builder.Services.AddGrpc(c => c.Interceptors.Add<GrpcExceptionHandler>());

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
    opt.TokenLifespan = TimeSpan.FromHours(1));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGrpcService<NotificationGrpcController>();

app.UseRabbitMq()
    .SubscribeEvent<UserUpdatedEvent>()
    .SubscribeEvent<UserDeletedEvent>();

app.UseAuthentication();
app.UseAuthorization();

app.UseInfrastucture();

app.MapGet("/", ctx => ctx.Response.WriteAsync($"Lapka.Notification API {DateTime.Now}"));
app.MapControllers();

app.Run();