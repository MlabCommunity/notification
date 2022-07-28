namespace Lappka.Notification.Application.Exceptions;

public abstract class ProjectException : Exception
{
    public int ErrorCode { get; }
    public object ExceptionData { get; protected set; }

    protected ProjectException(string message, int errorCode = 400, Exception innerException = null) : base(message,
        innerException)
    {
        ErrorCode = errorCode;
    }
}