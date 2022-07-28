using Microsoft.EntityFrameworkCore;
using Scheme.Core.Entities;
using Scheme.Infrastructure.Database.Config;

namespace Scheme.Infrastructure.Database.Contexts;

internal sealed class NotificationDbContext : DbContext, INotificationDbContext
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