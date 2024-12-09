using DotnetAuth.Domain.Entities;

namespace DotnetAuth.Service
{
    public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user);
        string GenerateRefreshToken();
    }
}
