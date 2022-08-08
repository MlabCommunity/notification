using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Lappka.Notification.Api.Controllers;
using Lappka.Notification.Application;
using Lappka.Notification.Application.Events;
using Lappka.Notification.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMiddleware();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<NotificationGrpcController>();

app.UseRabbitMq()
    .SubscribeEvent<UserCreatedEvent>()
    .SubscribeEvent<UserUpdatedEvent>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();