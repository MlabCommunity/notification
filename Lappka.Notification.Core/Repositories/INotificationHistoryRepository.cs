using Scheme.Core.Entities;

namespace Scheme.Core.Repositories;

public interface INotificationHistoryRepository
{
    Task<NotificationHistory> GetAsync(Guid notificationId);
    Task AddAsync(NotificationHistory notificationHistory);

    Task UpdateAsync(NotificationHistory notificationHistory);
}