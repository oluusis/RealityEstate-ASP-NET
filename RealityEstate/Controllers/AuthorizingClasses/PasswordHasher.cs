using System.Security.Cryptography;
using System.Text;

namespace RealityEstate.Controllers.AuthorizingClasses
{
    public class PasswordHasher
    {
        public static string HashPassword(string plainTextPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static bool VerifyPassword(string storedHash, string providedPassword)
        {
            string hashedPassword = HashPassword(providedPassword);
            return storedHash.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
