using TicketManager.DTO.Authentication;
using TicketManager.Model.ModelsNotMapped.Authentication;

namespace TicketManager.Service.IServices;

public interface IAuthService
{
    Task<string?> Login(LoginDto authenticationDto);
    void Register(Register register);
}