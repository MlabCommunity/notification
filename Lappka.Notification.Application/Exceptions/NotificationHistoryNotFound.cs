namespace Lappka.Notification.Application.Exceptions;

public class NotificationHistoryNotFound : ProjectException
{
    public NotificationHistoryNotFound( int errorCode = 404) : base("Notification history not found", errorCode)
    {
    }
}