// obiloveapi.Application/Interfaces/ICitizenRepository.cs
using System.Threading.Tasks;
using obiloveapi.Domain.Entities;

namespace obiloveapi.Application.Interfaces
{
    public interface ICitizenRepository
    {
        Task AddAsync(Citizen citizen);
        Task<Citizen?> GetByIdAsync(int citizenId);
        void Update(Citizen citizen);
        void Delete(Citizen citizen);
        Task SaveChangesAsync();
    }
}
