namespace TicketManager.Model.ModelsNotMapped.Exceptions;

public class ServiceException : Exception
{
    public object? ErrorObject { get; set; }

    public ServiceException(string message) : base(message)
    {}

    public ServiceException(string message, object errorObject) : base(message)
    {
        ErrorObject = errorObject;
    }
}