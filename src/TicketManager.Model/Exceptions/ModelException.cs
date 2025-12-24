namespace TicketManager.Model.Exceptions;

public class ModelException : Exception
{
    public object? ErrorObject { get; set; }

    public ModelException(string message) : base(message)
    {}

    public ModelException(string message, object errorObject) : base(message)
    {
        ErrorObject = errorObject;
    }
}