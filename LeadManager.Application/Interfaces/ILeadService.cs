using LeadManager.Domain.Entities;

namespace LeadManager.Application.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<Lead>> GetAllAsync();
        Task<IEnumerable<Lead>> GetAllInvitedAsync();
        Task<Lead> GetByIdAsync(int id);
        Task AddAsync(Lead invited);
        Task UpdateAsync(Lead invited);
        Task DeleteAsync(int id);
    }
}
