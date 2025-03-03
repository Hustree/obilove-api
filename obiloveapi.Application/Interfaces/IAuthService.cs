// obiloveapi.Application/Interfaces/IAuthService.cs
using System.Threading.Tasks;
using obiloveapi.Application.DTOs.Auth;

namespace obiloveapi.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginRequest request);
        // You can add registration, refresh tokens etc.
    }
}
