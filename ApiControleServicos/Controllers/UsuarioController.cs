using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
	[ApiController]
	[Route("api/v1/usuario")]
	public class UsuarioController : ControllerBase
	{
		public IActionResult Index()
		{
			return Ok();
		}
	}
}
