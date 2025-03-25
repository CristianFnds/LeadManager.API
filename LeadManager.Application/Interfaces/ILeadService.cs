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
        Task<Lead> AcceptLeadAsync(int id);
        Task<Lead> RejectLeadAsync(int id);
        Task DeleteAsync(int id);
    }
}
