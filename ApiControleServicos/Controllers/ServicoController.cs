using ApiControleServicos.Domain;
using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiControleServicos.Controllers
{
	[Authorize(Roles = "Admin,Employee")]
	[ApiController]
	[Route("api/v1/servico")]
	public class ServicoController : ControllerBase
	{
		private readonly IServicoServices _services;
		public ServicoController(IServicoServices services) 
		{
			_services = services;
		}

		[HttpGet]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				return Ok(await _services.GetById(id));
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet("close")]
		public async Task<IActionResult> GetAllClosed([Required]int empresaId, int page = 1, int itensPerPage = 10)
		{
			try
			{
				var servicoList = await _services.GetAllClosed(empresaId, page, itensPerPage);
				return Ok(servicoList);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpGet("open")]
		public async Task<IActionResult> GetAllOpen([Required]int empresaId, int page = 1, int itensPerPage = 10)
		{
			try
			{
				var servicoList = await _services.GetAllOpen(empresaId, page, itensPerPage);
				return Ok(servicoList);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateServicoModel novoServico)
		{
			try
			{
				await _services.Create(novoServico);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch]
		public async Task<IActionResult> Update([FromBody] UpdateServicoModel servico)
		{
			try
			{
				await _services.Update(servico);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch("finalizar")]
		public async Task<IActionResult> FinalizarServico([Required]int servicoId, [Required]double faturamento)
		{
			try
			{
				await _services.FinalizarServico(servicoId, faturamento);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch("cancel")]
		public async Task<IActionResult> CancelarServico([Required]int servicoId)
		{
			try
			{
				await _services.CancelarServico(servicoId);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
