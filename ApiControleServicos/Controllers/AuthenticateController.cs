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

        public AuthenticateController(ITokenServices tokenServices, IUsuarioServices services,
            IEmpresaServices empresa)
        {
            _tokenServices = tokenServices;
            _usuarioServices = services;
            _empresaServices = empresa;
        }

        [HttpPost]
		public async Task<IActionResult> Authentication([FromBody] LoginModel login)
		{
 			try
			{
				var usuarioDataBase = await _usuarioServices.GetByUserName(login.Email ?? "");

				if (usuarioDataBase.Id == 0)
					return Unauthorized("Email ou senha invalidos");

				if (login.Password != CriptoServices.Descriptografa(usuarioDataBase.Password ?? ""))
					return Unauthorized("Email ou senha invalidos");

				var token = _tokenServices.GenerateToken(usuarioDataBase);
				return Ok(token);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("GeneratePassToken")]
		public async Task<IActionResult> GeneratePasswordToken(string email)
		{
			try
			{
				var userDataBase = await _usuarioServices.GetByUserName(email);
				if(userDataBase.Id == 0){
					return Unauthorized("Email inválido");
				}
			
				return Ok(_tokenServices.GenerateToken(userDataBase, 3, false));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost("create")]
		public async Task<IActionResult> CreateAccount([FromBody] CreateContaModel novaConta)
		{
			try
			{
				var userVerify = await _usuarioServices.GetByUserName(novaConta.Usuario.Email);
				if (userVerify.Id != 0)
				{
					return Unauthorized("O email digitado ja está cadastrado no sistema");
				}

				if (novaConta?.Empresa is null || novaConta?.Usuario is null)
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
