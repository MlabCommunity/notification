namespace Lapka.Notification.Core.Domain.Entities;

public class NotificationHistory : ICreatedAt
{
    public Guid Id { get; init; }
    public NotificationType Type { get; init; }
    public string UserEmail { get; init; }
    public string Subject { get; init; }
    public string Body { get; init; }
    public DateTime CreatedAt { get; set; }
    public bool IsSend { get; private set; }
    public Guid UserId { get; init; }

    public void SetIsSend()
    {
        IsSend = true;
    }
}