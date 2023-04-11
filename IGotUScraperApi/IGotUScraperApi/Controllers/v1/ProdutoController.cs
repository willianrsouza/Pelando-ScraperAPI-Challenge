using IGotUScraper.Application.Handlers.ProdutoHandlers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        /// Obter Dados do Produto Por URL
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpPost(), MapToApiVersion("1.0")]
        public async Task<IActionResult> ObterDadosProduto([FromBody] ObterDadosProdutoQuery query)
        {
            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }
    }
}
