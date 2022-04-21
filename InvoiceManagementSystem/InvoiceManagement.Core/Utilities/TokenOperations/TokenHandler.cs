using InvoiceManagement.Core.Entities.Concretes;
using InvoiceManagement.Core.Utilities.TokenOperations.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace InvoiceManagement.Core.Utilities.TokenOperations
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(60);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenModel.Expiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: credentials
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;

        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, $"{user.FullName}"));
            claims.Add(new Claim(ClaimTypes.Role, user.OperationClaim));

            return claims;
        }
    }
}
