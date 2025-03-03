// obiloveapi.Infrastructure/Repositories/UserRepository.cs
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using obiloveapi.Application.Interfaces;
using obiloveapi.Domain.Entities;
using obiloveapi.Infrastructure.Data;

namespace obiloveapi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _context.Users
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
