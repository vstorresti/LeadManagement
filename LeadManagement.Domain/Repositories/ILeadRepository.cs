using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;

namespace LeadManagement.Domain.Repositories
{
    public interface ILeadRepository
    {
        Task AddAsync(Lead lead);
        Task<Lead> GetByIdAsync(int id);
        Task UpdateAsync(Lead lead);
        Task<IEnumerable<Lead>> GetByStatusAsync(EnLeadStatus status);
    }
}
