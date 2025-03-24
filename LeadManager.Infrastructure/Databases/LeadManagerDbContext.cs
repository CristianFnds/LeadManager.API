using LeadManager.Domain.Entities;
using LeadManager.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Infrastructure.Databases
{
    public class LeadManagerDbContext : DbContext
    {
        public LeadManagerDbContext(DbContextOptions<LeadManagerDbContext> options)
           : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LeadConfigurations());
            modelBuilder.ApplyConfiguration(new ContactConfigurations());
        }
    }
}
