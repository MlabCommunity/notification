using Lappka.Notification.Core.Entities;
using Lappka.Notification.Infrastructure.Database.Config;
using Microsoft.EntityFrameworkCore;

namespace Lappka.Notification.Infrastructure.Database.Contexts;

public class NotificationDbContext : DbContext, INotificationDbContext
{
    public DbSet<NotificationHistory> NotificationsHistory { get; set; }
    public DbSet<UserData> UsersData { get; set; }

    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        var configuration = new EntitiesConfig();
        builder.ApplyConfiguration<UserData>(configuration);
        builder.ApplyConfiguration<NotificationHistory>(configuration);
        
        base.OnModelCreating(builder);
    }
}