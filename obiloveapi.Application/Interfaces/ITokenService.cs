// obiloveapi.Application/Interfaces/ITokenService.cs
namespace obiloveapi.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
