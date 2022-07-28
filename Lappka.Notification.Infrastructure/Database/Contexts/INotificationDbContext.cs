using Microsoft.EntityFrameworkCore;
using Scheme.Core.Entities;

namespace Scheme.Infrastructure.Database.Contexts;

public interface INotificationDbContext
{
    DbSet<NotificationHistory> NotificationsHistory { get; set; }
    DbSet<UserData> UsersData { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}