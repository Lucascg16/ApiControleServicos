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
		private readonly IEmpresaServices _empresaServices;
		public AuthenticateController(ITokenServices tokenServices, IUsuarioServices services, IEmpresaServices empresa) 
		{
			_tokenServices = tokenServices;
			_usuarioServices = services;
			_empresaServices = empresa;
		}

		[HttpPost]
		public async Task<IActionResult> Authentication(string email, string password)
		{
			var usuarioDataBase = await _usuarioServices.GetByUserName(email);

			if (usuarioDataBase.Id == 0)
				return Unauthorized("Email ou senha invalidos");

			if(password != usuarioDataBase.Password)
				return Unauthorized("Email ou senha invalidos");

			var token = _tokenServices.GenerateToken(usuarioDataBase);
			return Ok(token);
		}

		[HttpPost("usuario")]
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

		[HttpPost("empresa")]
		public async Task<IActionResult> CreateEmpresa([FromForm] CreateEmpresaModel novaEmpresa)
		{
			try
			{
				await _empresaServices.Create(novaEmpresa);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
