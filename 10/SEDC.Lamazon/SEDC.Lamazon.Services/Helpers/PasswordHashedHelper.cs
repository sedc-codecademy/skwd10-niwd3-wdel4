using Microsoft.AspNetCore.Identity;
using SEDC.Lamazon.Domain.Enitities;

namespace SEDC.Lamazon.Services.Helpers
{
    public static class PasswordHashedHelper
    {
        private static PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public static void HashPassword(User user, string password)
        {
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
        }

        public static PasswordVerificationResult VerifyHashedPassword(User user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        }
    }
}
