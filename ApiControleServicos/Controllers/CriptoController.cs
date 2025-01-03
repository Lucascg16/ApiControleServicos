using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
    [ApiController]
    [Route("api/v1/criptografia")]
    public class CriptoController : ControllerBase
    {
        private readonly CriptoServices _criptoServices;
        private readonly IConfiguration _config;

        public CriptoController(CriptoServices criptoServices, IConfiguration config)
        {
            _criptoServices = criptoServices;
            _config = config;
        }

        [HttpGet("cript")]
        public IActionResult Cript(string input)
        {
            return Ok(_criptoServices.Criptografa(input));
        }

        [HttpGet("decript")]
        [Authorize]
        public IActionResult Decript(string input)
        {
            return Ok(CriptoServices.Descriptografar(input, _config));
        }
    }
}
