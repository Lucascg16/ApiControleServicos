using ApiControleServicos.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiControleServicos.Infra
{
	public class TokenServices : ITokenServices
	{
		public string GenerateToken(UsuarioModel usuario, int expires = 2) 
		{
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
			var issuer = Settings.Issuer;
			var audience = Settings.Audience;

			var tokenOptions = new JwtSecurityToken(
				issuer: issuer,
				audience: audience,
				claims:
                [
                    new Claim("id", usuario.Id.ToString()),
					new Claim("role", usuario.Role.ToString())
				],
				expires: DateTime.Now.AddHours(expires),
				signingCredentials: signingCredentials
			);

			return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
		}
	}
}
