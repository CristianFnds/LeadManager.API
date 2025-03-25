using LeadManager.Application.Interfaces;
using LeadManager.Domain.Entities;
using LeadManager.Domain.Interfaces;
using SendGrid.Helpers.Errors.Model;

namespace LeadManager.Application.Service
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository invitedRepository)
        {
            _leadRepository = invitedRepository;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await _leadRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Lead>> GetAllInvitedAsync()
        {
            return await _leadRepository.GetAllInvitedAsync();
        }

        public async Task<Lead> GetByIdAsync(int id)
        {
            return await _leadRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Lead invited)
        {
            await _leadRepository.AddAsync(invited);
        }

        public async Task UpdateAsync(Lead invited)
        {
            await _leadRepository.UpdateAsync(invited);
        }

        public async Task<Lead> AcceptLeadAsync(int id)
        {
            var lead = await _leadRepository.GetByIdAsync(id);
            if (lead == null)
            {
                throw new NotFoundException("Lead not found.");
            }

            lead.Accept();

            await _leadRepository.UpdateAsync(lead);

            return lead;
        }

        public async Task<Lead> RejectLeadAsync(int id)
        {
            var lead = await _leadRepository.GetByIdAsync(id);
            if (lead == null)
            {
                throw new NotFoundException("Lead not found.");
            }

            lead.Reject();

            await _leadRepository.UpdateAsync(lead);

            return lead;
        }

        public async Task DeleteAsync(int id)
        {
            await _leadRepository.DeleteAsync(id);
        }
    }
}
