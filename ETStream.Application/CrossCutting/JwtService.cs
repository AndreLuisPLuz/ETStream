using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ETStream.Application.Errors;
using ETStream.Domain.Aggregates.User;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ETStream.Application.CrossCutting
{
    public class JwtService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly JwtSettings _jwtSetings;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly SymmetricSecurityKey _securityKey;
        private readonly SigningCredentials _credentials;

        public JwtService(
                IServiceProvider serviceProvider,
                JwtSettings jwtSettings,
                JwtSecurityTokenHandler tokenHandler)
        {
            _serviceProvider = serviceProvider;
            _jwtSetings = jwtSettings;
            _tokenHandler = tokenHandler;

            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetings.SecretKey));
            _credentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512);
        }

        public string GenerateToken(AuthenticationResult.Succeeded auth)
        {
            var claims = new List<Claim>
            {
                new("UserId", auth.UserId.ToString())
            };

            var SecToken = new JwtSecurityToken(
                "ETStream",
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: _credentials);
            
            var token = _tokenHandler.WriteToken(SecToken);
            return token!;
        }

        public void ValidateToken(string jwt)
        {
            ClaimsPrincipal? claims;

            try
            {
                claims = _tokenHandler.ValidateToken(jwt,
                        new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidateAudience = false,
                            ValidIssuer = "ETStream",
                            IssuerSigningKey = _securityKey
                        },
                        out var validatedToken);
            }
            catch (SecurityTokenException ex)
            {
                throw new InvalidTokenException("Unable to validate token and its claims.", ex);
            }

            using var scope = _serviceProvider.CreateScope();
            var userContext = scope.ServiceProvider.GetRequiredService<UserContext>();
            
            userContext.Fill(new ContextData
            {
                UserId = Guid.Parse(claims.FindFirst("userId")!.Value)
            });
        }
    }
}