using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManager.Infrastructure.Configurations
{
    public class ContactConfigurations : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {

            builder.ToTable("Contacts");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.DateCreated)
                .HasColumnName("created_at")
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(c => c.Leads)
                .WithOne(l => l.Contact)
                .HasForeignKey(l => l.ContactId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
