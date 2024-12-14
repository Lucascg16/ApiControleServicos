using ApiControleServicos.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiControleServicos.Infra
{
	public class TokenServices : ITokenServices
	{
		private readonly IConfiguration _config;

        public TokenServices(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UsuarioModel usuario, int expires = 2) 
		{

            var secrat = _config.GetSection("ApiSettings")["Secret"]; //secrat == secret
            var key = Encoding.ASCII.GetBytes(string.IsNullOrEmpty(secrat) ? throw new("O secret é necessário para gerar o token") : secrat);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

			var tokenOptions = new JwtSecurityToken(
				issuer: _config.GetSection("ApiSettings")["Issuer"] ?? "",
				audience: _config.GetSection("ApiSettings")["Audience"] ?? "",
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
