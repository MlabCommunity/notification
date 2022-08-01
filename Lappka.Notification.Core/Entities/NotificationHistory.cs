using Lappka.Notification.Core.Consts;

namespace Lappka.Notification.Core.Entities;

public class NotificationHistory
{
    public Guid Id { get;  set; }
    public EventType EventType { get; private set; }
    public UserData User { get; private set; }
    public string Subject{ get; private set; }
    public string Body{ get; private set; }
    public bool isSent{ get; private set; }
    public DateTime CreatedAt { get; private set; }

    private NotificationHistory()
    {
    }
    
    public NotificationHistory(Guid id, EventType eventType, UserData user, string subject, string body)
    {
        Id = id;
        EventType = eventType;
        User = user;
        Subject = subject;
        Body = body;
        isSent = false;
        CreatedAt = DateTime.UtcNow;
    }

    public void SendNotification()
    {
        isSent = true;
    }
}