namespace Scheme.Core.Entities;

public class UserData
{
    public Guid UserId { get; private set; }
    public ICollection<NotificationHistory> Notifications { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    
}