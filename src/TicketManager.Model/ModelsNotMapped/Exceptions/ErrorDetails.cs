using System.Text.Json;

namespace TicketManager.Model.ModelsNotMapped.Exceptions;

public class ErrorDetails
{
    public int StatusCode { get; private set; }
    public string Message { get; private set; }
    public object? ErrorObject { get; private set; }

    public ErrorDetails(int statusCode, string message, object? errorObject)
    {
        StatusCode = statusCode;
        Message = message;
        ErrorObject = errorObject;
        this.IsValid();
    }

    private void IsValid()
    {
        if (StatusCode < 100 || StatusCode > 599)
            throw new ModelException("Status code must be between 100 and 599.");

        if (string.IsNullOrWhiteSpace(Message))
            throw new ModelException("Message cannot be null or empty.");
    }

    public override string ToString() => JsonSerializer.Serialize(this);
}