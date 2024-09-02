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
		private readonly ICriptoServices _criptoServices;
		public AuthenticateController(ITokenServices tokenServices, IUsuarioServices services, 
			IEmpresaServices empresa, ICriptoServices criptoServices)
		{
			_tokenServices = tokenServices;
			_usuarioServices = services;
			_empresaServices = empresa;
			_criptoServices = criptoServices;
		}

		[HttpPost]
		public async Task<IActionResult> Authentication(string email, string password)
		{
			var usuarioDataBase = await _usuarioServices.GetByUserName(email);

			if (usuarioDataBase.Id == 0)
				return Unauthorized("Email ou senha invalidos");

			if(_criptoServices.Criptografa(password) != usuarioDataBase.Password)
				return Unauthorized("Email ou senha invalidos");

			var token = _tokenServices.GenerateToken(usuarioDataBase);
			return Ok(token);
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateAccount([FromForm] CreateContaModel novaConta)
		{
			try
			{
				if (novaConta is null || novaConta.Empresa is null || novaConta.Usuario is null)
					return BadRequest();

				await _empresaServices.Create(novaConta.Empresa);
				var empresa = _empresaServices.GetByName(novaConta.Empresa.Nome);

				novaConta.Usuario.EmpresaId = empresa.Id;
				await _usuarioServices.Create(novaConta.Usuario);

				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
