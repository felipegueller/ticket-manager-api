using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManager.Model.Models;

namespace TicketManager.Infrastructure.EntityConfigurations;

public class SuportAgentEntityConfiguration : BaseEntityConfiguration<SuportAgent>
{
public SuportAgentEntityConfiguration() : base("suport_agents")
    {}

    public override void Configure(EntityTypeBuilder<SuportAgent> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Email)
            .HasColumnName("email")
            .IsRequired()
            .HasMaxLength(200);
    }
}