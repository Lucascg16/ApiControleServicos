using ApiControleServicos.Domain;
using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Controllers
{
	[Authorize(Roles = "Admin,Employee")]
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
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet("All")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAll([Required]int empresaId, int page = 1, int itensPerPage = 10)
		{
			try
			{
				var usuarioList = await _usuarioServices.GetAll(empresaId ,page, itensPerPage);
				return Ok(usuarioList);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUsuarioModel novoUsuario)
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

		[HttpPatch]
		public async Task<IActionResult> Update([FromBody] UpdateUsuarioModel usuario)
		{
			try
			{
				await _usuarioServices.Update(usuario);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch("role")]
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> UpdateRole(int id, [Required] string role)
		{
			try
			{
				await _usuarioServices.UpdateRole(id, role);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch("password")]
		public async Task<IActionResult> UpdateSenha(int id, [Required] string senha)
		{
			try
			{
				await _usuarioServices.UpdateSenha(id, senha);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
