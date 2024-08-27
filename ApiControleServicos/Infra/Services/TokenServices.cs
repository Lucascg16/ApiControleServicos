﻿using ApiControleServicos.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiControleServicos.Infra.Services
{
	public class TokenServices
	{
		public static object GenerateToken(UsuarioModel usuario)
		{
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenConfig = new SecurityTokenDescriptor
			{
				Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
				{
					new Claim("usuarioId", usuario.Id.ToString()),
				}),
				Expires = DateTime.Now.AddHours(4),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var tokenHand = new JwtSecurityTokenHandler();
			var token = tokenHand.CreateToken(tokenConfig);

			return new
			{
				Token = tokenHand.WriteToken(token)
			};
		}
	}
}
