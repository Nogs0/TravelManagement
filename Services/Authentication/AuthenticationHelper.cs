using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelManagement.Models.Users;

namespace TravelManagement.Services.Authentication
{
    public class AuthenticationHelper
    {
        private static JWTSettings _jwtSettings;

        public static void Configure(JWTSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        private static List<Claim> GenerateClaims(UserModel user)
        {
            return new List<Claim>
            {
                new Claim("LoggedUserId", user.Id.ToString())
            };
        }

        public static string GenerateJWTToken(UserModel user)
        {
            var claims = GenerateClaims(user);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
