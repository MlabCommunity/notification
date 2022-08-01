using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Lappka.Notification.Api.Controllers;
using Lappka.Notification.Application;
using Lappka.Notification.Application.Events;
using Lappka.Notification.Infrastructure;
using Lappka.Notification.Infrastructure.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMiddleware();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
var app = builder.Build();

app.MapGrpcService<NotificationGrpcController>();

app.UseRabbitMq()
    .SubscribeEvent<UserCreatedEvent>()
    .SubscribeEvent<UserUpdatedEvent>();

// Configure the HTTP request pipeline.
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