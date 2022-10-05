using SEDC.Lamazon.Domain.Constants;
using System.Linq;
using System.Security.Claims;

namespace SEDC.Lamazon.Extensions
{
    public static class IdentityExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.IsInRole(Roles.Admin);
        }

        public static string DisplayName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value ?? string.Empty;
        }
    }
}
