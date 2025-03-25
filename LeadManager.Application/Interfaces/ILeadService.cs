using LeadManager.Domain.Entities;

namespace LeadManager.Application.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<Lead>> GetAllAsync();
        Task<IEnumerable<Lead>> GetAllInvitedAsync();
        Task<IEnumerable<Lead>> GetAllAcceptedsAsync();
        Task<Lead> GetByIdAsync(int id);
        Task AddAsync(Lead lead);
        Task UpdateAsync(Lead lead);
        Task<Lead> AcceptLeadAsync(Lead lead);
        Task<Lead> RejectLeadAsync(Lead lead);
        Task DeleteAsync(int id);
    }
}
