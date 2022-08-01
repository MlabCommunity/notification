namespace Lappka.Notification.Core.Entities;

public class UserData
{
    public Guid UserId { get;  set; }
    public ICollection<NotificationHistory> Notifications { get; private set; }
    public string Email { get; private set; }
    public string UserName { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private UserData()
    {
    }
    
    public UserData(Guid userId, string email, string userName, string firstName, string lastName)
     {
          UserId = userId;
          Email = email;
          UserName = userName;
          FirstName = firstName;
          LastName = lastName;
          Notifications = new List<NotificationHistory>();
     }
    
    public void Update(string email, string userName, string firstName, string lastName)
    {
        Email = email;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
    }
    
}