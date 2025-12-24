using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManager.Model.Models;

namespace TicketManager.Infrastructure.EntityConfigurations;

public class TicketEntityConfiguration : BaseEntityConfiguration<Ticket>
{
    public TicketEntityConfiguration() : base("tickets")
    {}

    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Title)
            .HasColumnName("title")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .IsRequired();
    }
}