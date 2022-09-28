using Lapka.Notification.Core.Domain.Entities;

namespace Lapka.Notification.Application.Interfaces;

public interface INotificationHistoryRepository
{
    Task CreateNotification(NotificationHistory notification);
    Task MarkAsSend(Guid id);
    Task<List<NotificationHistory>> GetUnsentNotificationForsubscribers();
    Task UpdateNotifications(List<NotificationHistory> notificationHistories);
}