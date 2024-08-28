using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
	[ApiController]
	[Route("api/v1/auth")]
	public class AuthenticateController : ControllerBase
	{
		private readonly ITokenServices _tokenServices;
		public AuthenticateController(ITokenServices tokenServices) 
		{
			_tokenServices = tokenServices;
		}

		[HttpPost]
		public IActionResult Authentication(string username, string password)
		{
			if(username == "lucas" && password == "123")
			{
				var token = _tokenServices.GenerateToken(new Domain.Models.UsuarioModel());
				return Ok(token);
			}

			return Unauthorized("Username ou senha invalidos");
		}
	}
}
