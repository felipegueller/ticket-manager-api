using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketManager.Model.Models;

namespace TicketManager.Infrastructure.EntityConfigurations;

public abstract class BaseEntityConfiguration<T>(string tableName) : IEntityTypeConfiguration<T> where T : BaseModel
{
    private readonly string _tableName = tableName;

    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        if (!string.IsNullOrEmpty(_tableName))
            builder.ToTable(_tableName);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("createdat")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updatedat")
            .IsRequired();
    }
}