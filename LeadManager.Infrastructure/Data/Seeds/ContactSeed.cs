using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Infrastructure.Data.Seeds
{
    public class ContactSeed : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", Phone = "123-456-7890", Email = "john.doe@example.com", DateCreated = DateTime.UtcNow },
                new Contact { Id = 2, FirstName = "Jane", LastName = "Smith", Phone = "987-654-3210", Email = "jane.smith@example.com", DateCreated = DateTime.UtcNow },
                new Contact { Id = 3, FirstName = "Alice", LastName = "Johnson", Phone = "555-123-4567", Email = "alice.johnson@example.com", DateCreated = DateTime.UtcNow },
                new Contact { Id = 4, FirstName = "Bob", LastName = "Brown", Phone = "444-987-6543", Email = "bob.brown@example.com", DateCreated = DateTime.UtcNow },
                new Contact { Id = 5, FirstName = "Charlie", LastName = "Davis", Phone = "333-222-1111", Email = "charlie.davis@example.com", DateCreated = DateTime.UtcNow }
            );
        }
    }
}