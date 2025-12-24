using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.EntityConfigurations;
using TicketManager.Infrastructure.Seeds;

namespace TicketManager.Infrastructure.Contexts;

public class TicketManagerDbContext(
    DbContextOptions<TicketManagerDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply entity configurations
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TicketEntityConfiguration());
        modelBuilder.ApplyConfiguration(new SuportAgentEntityConfiguration());

        // Apply seeds
        DatabaseSeeder.SeedUsers(modelBuilder);
        DatabaseSeeder.SeedTickets(modelBuilder);
    }
}