using System.Security.Cryptography;
using System.Text;
using TravelManagement.Dtos.Authentication;
using TravelManagement.Models.Shared.AuditedEntity;

namespace TravelManagement.Models.Users
{
    public class UserModel : AuditedEntity<long>
    {
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }

        public void SetPassword(string password)
        {
            GenerateSalt();
            HashedPassword = HashPassword(password, Salt);
        }

        private void GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Salt = salt;
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

        public bool IsCorrectPassword(string password)
        {
            return HashedPassword == HashPassword(password, Salt);
        }

        public UserModel() { }

        public UserModel(SignUpInput input)
        {
            Username = input.Username;
            SetPassword(input.Password);
        }
    }
}
