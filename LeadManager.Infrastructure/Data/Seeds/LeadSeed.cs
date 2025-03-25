using LeadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManager.Infrastructure.Data.Seeds
{
    public class LeadSeed : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.HasData(
                new Lead { Id = 1, ContactId = 1, Suburb = "Downtown", Category = "Real Estate", Description = "Spacious apartment with a great view", Price = 300000.00m, DateCreated = DateTime.UtcNow },
                new Lead { Id = 2, ContactId = 2, Suburb = "Suburbs", Category = "Automobile", Description = "Brand new car with excellent mileage", Price = 20000.00m, DateCreated = DateTime.UtcNow },
                new Lead { Id = 3, ContactId = 3, Suburb = "Uptown", Category = "Technology", Description = "Latest laptop with high-end specs", Price = 1500.00m, DateCreated = DateTime.UtcNow },
                new Lead { Id = 4, ContactId = 4, Suburb = "Beachfront", Category = "Real Estate", Description = "Beachfront house with a large yard", Price = 500000.00m, DateCreated = DateTime.UtcNow },
                new Lead { Id = 5, ContactId = 5, Suburb = "City Center", Category = "Furniture", Description = "Modern sofa set, brand new", Price = 800.00m, DateCreated = DateTime.UtcNow }
            );
        }
    }
}