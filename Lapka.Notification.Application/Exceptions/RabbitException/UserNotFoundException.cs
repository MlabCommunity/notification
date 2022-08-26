using System.Net;

namespace Lapka.Notification.Application.Exceptions.RabbitException;

public class UserNotFoundException : ProjectException
{
    public UserNotFoundException(Guid id, Exception inner = null)
        : base($"User with id: {id} not found.", HttpStatusCode.NotFound) { }
}