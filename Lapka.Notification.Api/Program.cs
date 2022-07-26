using Lapka.Notification.Application;
using Lapka.Notification.Infrastructure;
using Lapka.Notification.Infrastructure.DataBase;
using Lapka.Notification.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
    opt.TokenLifespan = TimeSpan.FromHours(1));


var connectionString = builder.Configuration.GetConnectionString("postgres");
builder.Services.AddDbContext<DataContext>(x => x.UseNpgsql(connectionString));
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGrpcService<NotificationGrpcService>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseInfrastucture();

app.MapControllers();

app.Run();