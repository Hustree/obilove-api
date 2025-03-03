// obiloveapi.Application/Interfaces/IUserRepository.cs
using System.Threading.Tasks;
using obiloveapi.Domain.Entities;

namespace obiloveapi.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByIdAsync(int userId);
        void Update(User user);
        void Delete(User user);
        Task SaveChangesAsync();
    }
}
