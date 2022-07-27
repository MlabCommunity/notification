using System.Net;

namespace Lapka.Notification.Application.Exceptions.UserDataException;

public class UserNotFoundException : ProjectException
{
    public UserNotFoundException(Exception inner = null)
        : base($"User not found", HttpStatusCode.NotFound) { }
}