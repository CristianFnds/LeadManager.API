using LeadManager.Domain.Entities;

namespace LeadManager.Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetAllAsync();
        Task<Lead> GetByIdAsync(int id);
        Task AddAsync(Lead invited);
        Task UpdateAsync(Lead invited);
        Task DeleteAsync(int id);
    }
}
