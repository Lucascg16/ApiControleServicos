using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
    [ApiController]
    [Route("api/v1/criptografia")]
    public class CriptoController : ControllerBase
    {
        [HttpGet("cript")]
        public IActionResult Cript(string input)
        {
            return Ok(CriptoServices.Criptografa(input));
        }

        [HttpGet("decript")]
        [Authorize]
        public IActionResult Decript(string input)
        {
            return Ok(CriptoServices.Descriptografa(input));
        }
    }
}
