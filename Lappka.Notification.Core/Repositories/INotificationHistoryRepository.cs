using Lappka.Notification.Core.Entities;

namespace Lappka.Notification.Core.Repositories;

public interface INotificationHistoryRepository
{
    Task<NotificationHistory> GetAsync(Guid notificationId);
    Task AddAsync(NotificationHistory notificationHistory);

    Task UpdateAsync(NotificationHistory notificationHistory);
}