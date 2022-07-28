namespace Lappka.Notification.Application.Exceptions;

public class UserDataNotFoundException : ProjectException
{
    public UserDataNotFoundException(int errorCode = 404) : base("User data not found", errorCode)
    {
    }
}