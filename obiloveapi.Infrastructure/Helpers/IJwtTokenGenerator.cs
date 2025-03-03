// obiloveapi.Infrastructure/Helpers/IJwtTokenGenerator.cs
namespace obiloveapi.Infrastructure.Helpers
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username);
    }
}
