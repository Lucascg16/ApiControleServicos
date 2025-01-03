using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
    [ApiController]
    [Route("api/v1/criptografia")]
    public class CriptoController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CriptoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("cript")]
        public IActionResult Cript(string input)
        {
            return Ok(CriptoServices.Criptografa(input, _config));
        }

        [HttpGet("decript")]
        [Authorize]
        public IActionResult Decript(string input)
        {
            return Ok(CriptoServices.Descriptografar(input, _config));
        }
    }
}
