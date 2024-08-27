using ApiControleServicos.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ApiControleServicos.Controllers
{
	[ApiController]
	[Route("api/v1/auth")]
	public class AuthenticateController : ControllerBase
	{
		[HttpPost]
		public IActionResult Authentication(string username, string password)
		{
			if(username == "lucas" && password == "123")
			{
				var token = TokenServices.GenerateToken(new Domain.Models.UsuarioModel());
				return Ok(token);
			}

			return BadRequest("usuario ou senha errado");
		}
	}
}
