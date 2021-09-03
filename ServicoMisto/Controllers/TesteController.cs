using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServicoMisto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Deu tudo certo");
        }
    }
}