using Lappka.Notification.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lappka.Notification.Infrastructure.Database.Contexts;

public interface INotificationDbContext
{
    DbSet<NotificationHistory> NotificationsHistory { get; set; }
    DbSet<UserData> UsersData { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}