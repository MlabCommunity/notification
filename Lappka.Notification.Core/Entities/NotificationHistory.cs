using Scheme.Core.Consts;

namespace Scheme.Core.Entities;

public class NotificationHistory
{
    public Guid Id { get; private set; }
    private EventType EventType;
    public UserData User { get; private set; }
    private string Subject;
    private string Body;
    private bool isSent;
    private DateTime CreatedAt;

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