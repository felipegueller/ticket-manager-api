using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManager.Model.Models;

namespace TicketManager.Infrastructure.EntityConfigurations;

public class UserEntityConfiguration : BaseEntityConfiguration<User>
{
    public UserEntityConfiguration() : base("users")
    {}

    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Username)
            .HasColumnName("username")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Password)
            .HasColumnName("password")
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(p => p.Tickets)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}