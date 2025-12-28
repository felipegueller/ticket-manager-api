namespace TicketManager.DTO.Authentication;

public class RegisterDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirmation { get; set; }
    public string? Email { get; set; }

    public Model.ModelsNotMapped.Authentication.Register ToModel()
    {
        return AuthenticationProfile
            .GetMappedObject<Model.ModelsNotMapped.Authentication.Register>(this);
    }
}