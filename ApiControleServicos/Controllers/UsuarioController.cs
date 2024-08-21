using ApiControleServicos.Domain;
using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Mvc;

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

		//criar um get all com paginação

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
