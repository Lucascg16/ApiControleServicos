using ApiControleServicos.Domain;
using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Controllers
{
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

		[HttpGet]
		[Route("All")]
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
		public async Task<IActionResult> Create([FromForm] CreateUsuarioModel novoUsuario)
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
		public async Task<IActionResult> Update([FromForm] UpdateUsuarioModel usuario)
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
	}
}
