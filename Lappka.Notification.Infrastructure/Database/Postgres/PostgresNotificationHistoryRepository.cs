using Lappka.Notification.Core.Entities;
using Lappka.Notification.Core.Repositories;
using Lappka.Notification.Infrastructure.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Lappka.Notification.Infrastructure.Database.Postgres;

internal sealed class PostgresNotificationHistoryRepository : INotificationHistoryRepository
{
    private readonly INotificationDbContext _context;
    
    public PostgresNotificationHistoryRepository(INotificationDbContext context)
    {
        _context = context;
    }

    public async Task<NotificationHistory> GetAsync(Guid notificationId)
    => await _context.NotificationsHistory.FirstOrDefaultAsync(x => x.Id == notificationId);

    public async Task AddAsync(NotificationHistory notificationHistory)
    {
        await _context.NotificationsHistory.AddAsync(notificationHistory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(NotificationHistory notificationHistory)
    {
        _context.NotificationsHistory.Update(notificationHistory);
        await _context.SaveChangesAsync();
    }
}