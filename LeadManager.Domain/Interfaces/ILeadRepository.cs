using LeadManager.Domain.Entities;

namespace LeadManager.Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetAllAsync();
        Task<IEnumerable<Lead>> GetAllInvitedAsync();
        Task<IEnumerable<Lead>> GetAllAcceptedsAsync();
        Task<Lead> GetByIdAsync(int id);
        Task AddAsync(Lead lead);
        Task UpdateAsync(Lead lead);
        Task LeadAccept(Lead lead);
        Task DeleteAsync(int id);
    }
}
