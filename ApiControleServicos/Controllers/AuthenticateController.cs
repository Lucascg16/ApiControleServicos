using ApiControleServicos.Domain;
using ApiControleServicos.Domain.CreatingUpdatingModels;
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
		public async Task<IActionResult> Authentication([FromForm] LoginModel login)
		{
			try
			{
				var usuarioDataBase = await _usuarioServices.GetByUserName(login.Email);

				if (usuarioDataBase.Id == 0)
					return Unauthorized("Email ou senha invalidos");

				if (_criptoServices.Criptografa(login.Password) != usuarioDataBase.Password)
					return Unauthorized("Email ou senha invalidos");

				var token = _tokenServices.GenerateToken(usuarioDataBase);
				return Ok(token);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateAccount([FromForm] CreateContaModel novaConta)
		{
			try
			{
				var userverify = await _usuarioServices.GetByUserName(novaConta.Usuario.Email);
				if (userverify.Id != 0)
				{
					return Unauthorized("O email digitado ja está cadastrado no sistema");
				}

				if (novaConta is null || novaConta.Empresa is null || novaConta.Usuario is null)
					return BadRequest();

				var empresaId = await _empresaServices.Create(novaConta.Empresa);

				novaConta.Usuario.EmpresaId = empresaId; //o ID e retornado na execucao do create.
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
