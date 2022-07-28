using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Lappka.Notification.Api.GrpcControllers;
using Lappka.Notification.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMiddleware();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpc();

builder.Services.AddConvey()
    .AddCommandHandlers()
    .AddInMemoryCommandDispatcher()
    .AddQueryHandlers()
    .AddInMemoryQueryDispatcher()
    .Build();


var app = builder.Build();

app.UseConvey();

app.MapGrpcService<NotificationGrpcController>();

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