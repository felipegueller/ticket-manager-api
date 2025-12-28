namespace TicketManager.Service.IServices;

public interface IAuthService
{
    void Login(string username, string password);
}