using Lappka.Notification.Application;
using Lappka.Notification.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGrpcService<NotificationGrpcService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();