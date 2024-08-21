using ApiControleServicos.Domain;
using ApiControleServicos.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
    [ApiController]
	[Route("api/v1/empresa")]
	public class EmpresaController : ControllerBase
	{
		private readonly IEmpresaServices _empresaServices;

		public EmpresaController(IEmpresaServices services) 
		{
			_empresaServices = services;
		}

		[HttpGet]
		public  async Task<IActionResult> GetById(int id)
		{
			try
			{
				var empresa = await _empresaServices.GetById(id);
				return Ok(empresa);
			}
			catch 
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] CreateEmpresaModel novaEmpresa)
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

		[HttpPatch]
		public async Task<IActionResult> Update([FromForm] UpdateEmpresaModel empresa)
		{
			try
			{
				await _empresaServices.Update(empresa);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
