using LeadManager.Domain.Entities;
using LeadManager.Domain.Interfaces;
using LeadManager.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadManagerDbContext _context;

        public LeadRepository(LeadManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await _context.Leads.Include(l => l.Contact).ToListAsync();
        }
        public async Task<IEnumerable<Lead>> GetAllInvitedAsync()
        {
            return await _context.Leads.Include(l => l.Contact).ToListAsync();
        }

        public async Task<Lead> GetByIdAsync(int id)
        {
            return await _context.Leads.FindAsync(id);
        }

        public async Task AddAsync(Lead lead)
        {
            await _context.Leads.AddAsync(lead);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var invited = await _context.Leads.FindAsync(id);
            if (invited != null)
            {
                _context.Leads.Remove(invited);
                await _context.SaveChangesAsync();
            }
        }
    }
}
