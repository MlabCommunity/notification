namespace Lapka.Notification.Core.Domain.Entities;

public class UserData
{
    public Guid Id { get; init; }
    public string Username { get; init; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public UserData(Guid id, string username, string firstname, string lastname, string email)
    {
        Id = id;
        Username = username;
        FirstName = firstname;
        LastName = lastname;
        Email = email;
    }

    private UserData()
    {
        
    }

    public void Update(string firstname, string lastname, string email)
    {
        if (!string.IsNullOrWhiteSpace(firstname))
            FirstName = firstname;

        if (!string.IsNullOrWhiteSpace(lastname))
            LastName = lastname;

        if (!string.IsNullOrWhiteSpace(email))
            Email = email;
    }
}