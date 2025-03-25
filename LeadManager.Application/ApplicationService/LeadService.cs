using LeadManager.Application.Interfaces;
using LeadManager.Domain.Entities;
using LeadManager.Domain.Interfaces;

namespace LeadManager.Application.ApplicationService
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IEmailService _emailService;

        private const string emailVendas = "vendas@teste.com";

        public LeadService(ILeadRepository invitedRepository, IEmailService emailService)
        {
            _leadRepository = invitedRepository;
            _emailService = emailService;
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await _leadRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Lead>> GetAllInvitedAsync()
        {
            return await _leadRepository.GetAllInvitedAsync();
        }
        public async Task<IEnumerable<Lead>> GetAllAcceptedsAsync()
        {
            return await _leadRepository.GetAllAcceptedsAsync();
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

        public async Task<Lead> AcceptLeadAsync(Lead lead)
        {
            if (lead.Price > 500)
            {
                lead.Price = lead.Price * 0.9m;
            }

            lead.Accept();

            await _leadRepository.UpdateAsync(lead);

            await _emailService.SendEmailAsync(emailVendas, "Lead Accepted", "Hello");

            return lead;
        }

        public async Task<Lead> RejectLeadAsync(Lead lead)
        {
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
