using System.Security.Cryptography;
using System.Text;
using TravelManagement.Models.Shared.AuditedEntity;

namespace TravelManagement.Models.Users
{
    public class UserModel : AuditedEntity<long>
    {
        public string Username { get; set; }
        public string NormalizedUsername { get; set; }
        private string HashedPassword { get; set; }
        private byte[] Salt { get; set; }
        private void GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Salt = salt;
        }

        public void SetPassword(string password)
        {
            GenerateSalt();
            HashedPassword = HashPassword(password, Salt);
        }

        private static string HashPassword(string password, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordWithSalt = Encoding.UTF8.GetBytes(password)
                                                    .Concat(salt)
                                                    .ToArray();

                var hash = sha256.ComputeHash(passwordWithSalt);
                return Convert.ToBase64String(hash);
            }
        }

        public bool VerifyPassword(string password)
        {
            return HashedPassword == HashPassword(password, Salt);
        }
    }
}
