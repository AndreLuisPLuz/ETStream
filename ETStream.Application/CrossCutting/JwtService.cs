using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ETStream.Domain.Aggregates.User;
using Microsoft.IdentityModel.Tokens;

namespace ETStream.Application.CrossCutting
{
    public class JwtService
    {
        private readonly JwtSettings _jwtSetings;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtService(
                JwtSettings jwtSettings,
                JwtSecurityTokenHandler tokenHandler)
        {
            _jwtSetings = jwtSettings;
            _tokenHandler = tokenHandler;
        }

        public string GenerateToken(AuthenticationResult.Succeeded auth)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>
            {
                new("UserId", auth.UserId.ToString())
            };

            var SecToken = new JwtSecurityToken(
                "ETStream",
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials);
            
            var token = _tokenHandler.WriteToken(SecToken);
            return token!;
        }
    }
}