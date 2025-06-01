using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Repositories;
using LeadManagement.Infrastructure.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadDbContext _context;

        public LeadRepository(LeadDbContext context) => _context = context;

        public async Task AddAsync(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
        }

        public async Task<Lead> GetByIdAsync(int id) => await _context.Leads.FindAsync(id);

        public async Task UpdateAsync(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lead>> GetByStatusAsync(EnLeadStatus status) =>
            await _context.Leads.Where(l => l.Status == status).ToListAsync();
    }
}
