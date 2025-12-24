using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Contexts;

namespace TicketManager.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Connection string 'DefaultConnection' not found.");

        services.AddDbContextPool<TicketManagerDbContext>(options =>
            {
                options.UseMySql(connectionString,
                    ServerVersion.Create(
                        new Version("8.0.44"),
                        Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql),
                    m =>
                    {
                        m.MigrationsAssembly("TicketManager.Infrastructure");
                    }
                )
                .LogTo(s => Debug.WriteLine(s))
                .EnableDetailedErrors(true)
                .EnableSensitiveDataLogging(true);
            }
        );

        return services;
    }
}