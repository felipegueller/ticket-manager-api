using TicketManager.Model.Exceptions;

namespace TicketManager.Model.Models;

public class User : BaseModel
{
    public User(string username, string password, string email)
    {
        this.Username = username;
        this.Email = email;
        this.Password = password;
        this.CreatedAt = DateTime.Now;
        this.UpdatedAt = DateTime.Now;
        this.IsValid();
    }

    public string? Username { get; private set; }
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public virtual ICollection<Ticket>? Tickets { get; private set; }

    private void IsValid()
    {
        if (string.IsNullOrWhiteSpace(Username))
            throw new ModelException("Username cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(Password))
            throw new ModelException("Password cannot be null or empty.");

        if (string.IsNullOrEmpty(this.Email))
            throw new ModelException("E-mail cannot be null or empty.");
    }
}