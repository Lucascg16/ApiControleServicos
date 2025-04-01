using ApiControleServicos.Domain;
using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Controllers
{
	[Authorize(Roles = "Admin,Funcionario")]
	[ApiController]
	[Route("api/v1/usuario")]
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioServices _usuarioServices;

		public UsuarioController(IUsuarioServices services)
		{
			_usuarioServices = services; 
		}

		[HttpGet]
		public async Task<IActionResult> GetById(int id) 
		{
			try
			{
				var usuario = await _usuarioServices.GetById(id);
				return Ok(usuario);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("vId")]
		public async Task<IActionResult> GetByVId(Guid id)
		{
			try
			{
				var usuario = await _usuarioServices.GetById(id);
				return Ok(usuario);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("total")]
		public async Task<IActionResult> GetAllNumber(int empresaId)
		{
			try
			{
				return Ok(await _usuarioServices.GetAllNumber(empresaId));
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("All")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll([Required]int empresaId, int page = 1, int itensPerPage = 10, string nome = "")
		{
			try
			{
				var usuarioList = await _usuarioServices.GetAll(empresaId, page, itensPerPage, nome);
				return Ok(usuarioList);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUsuarioModel novoUsuario)
		{
			try
			{
				var user = await _usuarioServices.GetByUserName(novoUsuario.Email);
                if (user.Id != 0)
					return Unauthorized("O Email digitado já existe na base de dados");

				await _usuarioServices.Create(novoUsuario);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPatch]
		public async Task<IActionResult> Update([FromBody] UpdateUsuarioModel usuario)
		{
			try
			{
				await _usuarioServices.Update(usuario);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _usuarioServices.Delete(id);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPatch("password")]
		public async Task<IActionResult> UpdateSenha(int id,  string novaSenha, string senha = "")
		{
			try
			{
				await _usuarioServices.UpdateSenha(id, senha, novaSenha);
				return Ok();
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
