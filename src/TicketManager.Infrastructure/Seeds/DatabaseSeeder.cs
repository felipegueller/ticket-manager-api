using Microsoft.EntityFrameworkCore;
using TicketManager.Model.Models;

namespace TicketManager.Infrastructure.Seeds;

public static class DatabaseSeeder
{
    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new {
                Username = "admin",
                Email = "admin@example.com",
                Password = "admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new {
                Username = "user",
                Email = "user@example.com",
                Password = "user",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        );
    }

    public static void SeedTickets(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ticket>().HasData(
            new {
                UserId = 2,
                Title = "First Ticket",
                Description = "This is the first ticket.",
                Status = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new {
                UserId = 2,
                Title = "Second Ticket",
                Description = "This is the second ticket.",
                Status = 0,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        );
    }
}