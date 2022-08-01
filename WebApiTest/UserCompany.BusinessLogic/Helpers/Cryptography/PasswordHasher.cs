using System.Security.Cryptography;
using System.Text;

namespace UserCompany.BusinessLogic.Helpers.Cryptography
{
    public class PasswordHasher
    {
        public static void HashPassword(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPassword(byte[] passwordSalt, byte[] userPasswordHash, string loginPassword)
        {
            var hmac = new HMACSHA512(passwordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginPassword));

            return hash.SequenceEqual(userPasswordHash);
        }
    }
}
