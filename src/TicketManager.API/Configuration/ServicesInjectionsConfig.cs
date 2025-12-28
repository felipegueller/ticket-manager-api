using TicketManager.Service.IServices;
using TicketManager.Service.Services;

namespace TicketManager.API.Configuration;

public static class ServicesInjectionsConfig
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        // services.AddScoped<IUserService, UserService>();
        // services.AddScoped<ITicketService, TicketService>();
        // services.AddScoped<ISuportAgentService, SuportAgentService>();

        return services;
    }
}