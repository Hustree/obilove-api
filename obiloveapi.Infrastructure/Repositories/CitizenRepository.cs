// obiloveapi.Infrastructure/Repositories/CitizenRepository.cs
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using obiloveapi.Application.Interfaces;
using obiloveapi.Domain.Entities;
using obiloveapi.Infrastructure.Data;

namespace obiloveapi.Infrastructure.Repositories
{
    public class CitizenRepository : ICitizenRepository
    {
        private readonly AppDbContext _context;

        public CitizenRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Citizen citizen)
        {
            await _context.Citizens.AddAsync(citizen);
        }

        public async Task<Citizen?> GetByIdAsync(int citizenId)
        {
            return await _context.Citizens
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.CitizenId == citizenId);
        }

        public void Update(Citizen citizen)
        {
            _context.Citizens.Update(citizen);
        }

        public void Delete(Citizen citizen)
        {
            _context.Citizens.Remove(citizen);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
