using LeadManager.Application.Interfaces;
using LeadManager.Domain.Entities;
using LeadManager.Domain.Interfaces;

namespace LeadManager.Application.Service
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _invitedRepository;

        public LeadService(ILeadRepository invitedRepository)
        {
            _invitedRepository = invitedRepository;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await _invitedRepository.GetAllAsync();
        }

        public async Task<Lead> GetByIdAsync(int id)
        {
            return await _invitedRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Lead invited)
        {
            await _invitedRepository.AddAsync(invited);
        }

        public async Task UpdateAsync(Lead invited)
        {
            await _invitedRepository.UpdateAsync(invited);
        }

        public async Task DeleteAsync(int id)
        {
            await _invitedRepository.DeleteAsync(id);
        }
    }
}
