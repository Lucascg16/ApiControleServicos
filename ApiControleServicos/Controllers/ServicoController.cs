using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
	[ApiController]
	[Route("api/v1/servico")]
	public class ServicoController : ControllerBase
	{
		[HttpGet]
		public IActionResult Index()
		{
			return Ok();
		}
	}
}
