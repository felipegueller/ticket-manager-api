using TicketManager.Model.Exceptions;

namespace TicketManager.Model.Models;

public class SuportAgent : BaseModel
{
    public SuportAgent(string name, string email)
    {
        this.Name = name;
        this.Email = email;
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
        this.IsValid();
    }

    public string? Name { get; private set; }
    public string? Email { get; private set; }

    private void IsValid()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new ModelException("Name cannot be null or empty.");

        if (string.IsNullOrEmpty(this.Email))
            throw new ModelException("E-mail cannot be null or empty.");
    }
}