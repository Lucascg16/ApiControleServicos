using ApiControleServicos.Infra;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleServicos.Controllers
{
    [ApiController]
    [Route("api/v1/criptografia")]
    public class CriptoController : ControllerBase
    {
        private readonly CriptoServices _criptoServices;

        public CriptoController(CriptoServices criptoServices)
        {
            _criptoServices = criptoServices;
        }

        [HttpGet("cript")]
        public IActionResult Cript(string input)
        {
            return Ok(_criptoServices.Criptografa(input));
        }

        [HttpGet("decript")]
        public IActionResult Decript(string input)
        {
            return Ok(_criptoServices.Descriptografar(input));
        }
    }
}
