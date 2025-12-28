using TicketManager.Model.ModelsNotMapped.Exceptions;
using TicketManager.Model.Utils;

namespace TicketManager.Model.ModelsNotMapped.Authentication;

public class Register
{
    public Register(
        string? username,
        string? password,
        string? passwordConfirmation,
        string? email)
    {
        Username = username;
        Password = password;
        PasswordConfirmation = passwordConfirmation;
        Email = email;

        this.IsValid();
    }

    public string? Username { get; private set; }
    public string? Password { get; private set; }
    public string? PasswordConfirmation { get; private set; }
    public string? Email { get; private set; }

    private void IsValid()
    {
        if (string.IsNullOrWhiteSpace(Username))
            throw new ModelException("Username cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(Password))
            throw new ModelException("Password cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(Password))
            throw new ModelException("Password cannot be null or empty.");

        if (!Password.Equals(PasswordConfirmation))
            throw new ModelException("Password and Password Confirmation do not match.");

        if (!EmailUtils.IsValidEmail(Email))
            throw new ModelException("E-mail is not valid.");
    }
}