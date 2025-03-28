﻿using LeadManager.Domain.Entities;
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
            return await _context.Leads.Include(l => l.Contact).Where(l => l.IsAccepted == null).ToListAsync();
        }

        public async Task<IEnumerable<Lead>> GetAllAcceptedsAsync()
        {
            return await _context.Leads.Include(l => l.Contact).Where(l => l.IsAccepted == true).ToListAsync();
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

        public async Task LeadAccept(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
                await _context.SaveChangesAsync();
            }
        }
    }
}
