using ApiControleServicos.Domain;
using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
	[ApiController]
	[Route("api/v1/auth")]
	public class AuthenticateController : ControllerBase
	{
		private readonly ITokenServices _tokenServices;
		private readonly IUsuarioServices _usuarioServices;
		public AuthenticateController(ITokenServices tokenServices, IUsuarioServices services) 
		{
			_tokenServices = tokenServices;
			_usuarioServices = services;
		}

		[HttpPost]
		public async Task<IActionResult> Authentication(string email, string password)
		{
			var usuarioDataBase = await _usuarioServices.GetByUserName(email);

			if (usuarioDataBase.Id == 0)
				return Unauthorized("Email ou senha invalidos");

			if(email == usuarioDataBase.Email && password == usuarioDataBase.Password)
			{
				var token = _tokenServices.GenerateToken(usuarioDataBase);
				return Ok(token);
			}

			return Unauthorized("Email ou senha invalidos");
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateAccount([FromForm] CreateUsuarioModel novoUsuario)
		{
			try
			{
				await _usuarioServices.Create(novoUsuario);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
