using LeadManager.Domain.Entities;

namespace LeadManager.Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetAllAsync();
        Task<IEnumerable<Lead>> GetAllInvitedAsync();
        Task<Lead> GetByIdAsync(int id);
        Task AddAsync(Lead invited);
        Task UpdateAsync(Lead invited);
        Task LeadAccept(Lead lead);
        Task DeleteAsync(int id);
    }
}
