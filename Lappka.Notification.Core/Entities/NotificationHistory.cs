using Lappka.Notification.Core.Consts;

namespace Lappka.Notification.Core.Entities;

public class Notification
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public EventType EventType { get; private set; }
    public UserData User { get; private set; }
    public string Subject { get; private set; }
    public string Body { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}