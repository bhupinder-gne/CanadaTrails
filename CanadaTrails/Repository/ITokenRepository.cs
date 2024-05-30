using Microsoft.AspNetCore.Identity;

namespace CanadaTrails.Repository
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
