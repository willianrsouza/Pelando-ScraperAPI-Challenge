using IGotUScraper.Application.Handlers.EmpresaHandlers.Query;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IGotUScraperApi.Controllers.v1
{
    /// <summary>
    /// Controller de Produto
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class EmrpesaController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public EmrpesaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obter Produto por Id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("{Id}"), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Obter Empresa Por Id", Description = "Obtém empresa cadastrada por Id.")]
        public async Task<IActionResult> ObterEmpresa([FromRoute] ObterEmpresaQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
  