using TicketManager.Model.ModelsNotMapped.Exceptions;
using TicketManager.Model.Utils;

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

        if (!EmailUtils.IsValidEmail(Email))
            throw new ModelException("E-mail is not valid.");
    }

    public void UpdatePassword(string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
            throw new ModelException("Password cannot be null or empty.");

        this.Password = newPassword;
        this.UpdatedAt = DateTime.Now;
    }
}