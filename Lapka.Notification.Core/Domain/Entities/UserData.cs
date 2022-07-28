namespace Lapka.Notification.Core.Domain.Entities;

public class UserData
{
    public Guid Id { get; init; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<NotificationHistory> Notifications { get; set; }
}