using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManager.Infrastructure.Configurations
{
    public class LeadConfigurations : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.ContactId)
                .HasColumnName("contact_id");

            builder.Property(l => l.Suburb)
                .HasMaxLength(100);

            builder.Property(l => l.Category)
                .HasMaxLength(50);

            builder.Property(l => l.Description)
                .HasMaxLength(500);

            builder.Property(l => l.Price)
                .HasColumnType("DECIMAL(10,2)");

            builder.Property(l => l.IsAccepted)
                .HasDefaultValue(null);

            builder.Property(l => l.DateCreated)
                .HasColumnName("created_at")
                .HasColumnType("datetime2(7)") // Escala válida no SQL Server
            .HasDefaultValueSql("GETDATE()"); // Valor padrão no SQL Server

            builder.HasOne(l => l.Contact)
               .WithMany(c => c.Leads)
               .HasForeignKey(l => l.ContactId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
