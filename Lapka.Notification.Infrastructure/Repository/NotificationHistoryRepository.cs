using Lapka.Notification.Application.Interfaces;
using Lapka.Notification.Core.Domain;
using Lapka.Notification.Core.Domain.Entities;
using Lapka.Notification.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Lapka.Notification.Infrastructure.Repository;

internal class NotificationHistoryRepository : INotificationHistoryRepository
{
    private readonly DataContext _context;

    public NotificationHistoryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task CreateNotification(NotificationHistory notification)
    {
        await _context.NotificationHistory.AddAsync(notification);
        await _context.SaveChangesAsync();
    }

    public async Task MarkAsSend(Guid id)
    {
        var notification = await _context.NotificationHistory.FirstOrDefaultAsync(x => x.Id == id);
        if (notification is not null)
        {
            notification.SetIsSend();
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateNotifications(List<NotificationHistory> notificationHistories)
    {
        _context.NotificationHistory.UpdateRange(notificationHistories);
        await _context.SaveChangesAsync();
    }

    public async Task<List<NotificationHistory>> GetUnsentNotificationForsubscribers() 
        => _context.NotificationHistory.Where(x => !x.IsSend && x.Type == NotificationType.Email_Forsubscribers).ToList();
}