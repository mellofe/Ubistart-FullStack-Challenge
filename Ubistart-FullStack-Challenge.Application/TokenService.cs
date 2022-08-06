using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Ubistart_FullStack_Challenge.Domain.Entities;
using Ubistart_FullStack_Challenge.Domain;

namespace Ubistart_FullStack_Challenge.Service
{
	public static class TokenService
	{
		public static string GenerateToken(User user)
		{
			JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(EnvironmentValues.Secret);
			SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Name),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(3),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
			return jwtSecurityTokenHandler.WriteToken(securityToken);
		}

		public static string GetValueFromClaim(IIdentity identity, string field)
		{
			ClaimsIdentity claims = (ClaimsIdentity)identity;

			return claims.FindFirst(field).Value;
		}

	}
}
