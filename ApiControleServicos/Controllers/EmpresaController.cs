﻿using ApiControleServicos.Domain;
using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
	[Authorize(Roles = "Admin")]
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
		public async Task<IActionResult> GetById(int id)
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

		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				return Ok(await _empresaServices.GetAll());
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPatch]
		public async Task<IActionResult> Update([FromBody] UpdateEmpresaModel empresa)
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

		[HttpDelete]
		public async Task<IActionResult> DesableAll(int id)
		{
			try
			{
				await _empresaServices.DesableAll(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
