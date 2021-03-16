using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negocio;
using Servico.Interface;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessoController : ControllerBase
    {
        private readonly ILogger<ProcessoController> _logger;
        private IProcessoServico _processoService;
        public ProcessoController(ILogger<ProcessoController> logger, IProcessoServico processoService)
        {
            _logger = logger;
            _processoService = processoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_processoService.ObtenhaTodos());
        }

        [HttpGet("{numeroDoProcesso}")]
        public IActionResult Get(string numeroDoProcesso)
        {
            var processo = _processoService.ObtenhaProcessoPorNumero(numeroDoProcesso);
            if (processo == null)
            {
                return NotFound();
            }

            return Ok(processo);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Processo processo)
        {
            if (processo == null)
            {
                return BadRequest();
            }

            return Ok(_processoService.Insira(processo));
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Processo processo)
        {
            if (processo == null)
            {
                return BadRequest();
            }

            return Ok(_processoService.Atualize(processo));
        }

        [HttpDelete("{numeroDoProcesso}")]
        public IActionResult Delete(string numeroDoProcesso)
        {
            _processoService.Exclua(numeroDoProcesso);

            return NoContent();
        }
    }
}
