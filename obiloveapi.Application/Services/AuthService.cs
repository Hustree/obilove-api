// obiloveapi.Application/Services/AuthService.cs
using System.Threading.Tasks;
using obiloveapi.Application.DTOs.Auth;
using obiloveapi.Application.Interfaces;

namespace obiloveapi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginRequest request)
        {
            // Here you would normally verify the user's credentials.
            // For this demo, we simply generate a token using the token service.
            return await Task.FromResult(_tokenService.GenerateToken(request.Username));
        }
    }
}
