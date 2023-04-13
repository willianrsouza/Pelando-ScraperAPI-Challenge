using IGotUScraper.Application.Handlers.ProdutoHandlers.Command;
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
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obter Dados do Produto
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpPost(), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Consultar Produto", Description = "Obtém dados do produto.")]
        public async Task<IActionResult> ConsultarProduto([FromBody] ConsultarDadosProdutoCommand query)
        {
            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }

        /// <summary>
        /// Obter Produto por Id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("{Id}"), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Obter Produto", Description = "Obtém produto por Id.")]
        public async Task<IActionResult> ObterProduto([FromRoute] ObterProdutoQuery query)
        {
            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }
    }
}
