using IGotUScraper.Application.Handlers.ProdutoHandlers.Command;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto;
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
        /// Controller Produto
        /// </summary>
        /// <param name="mediator"></param>
        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Consultar - Cadastras Produto Por 'URL' 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpPost(), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Consultar - Cadastras Produto Por 'URL' ", Description = "Consultar - Cadastras dados de um produto.")]
        public async Task<IActionResult> ConsultarProduto([FromBody] ConsultarDadosProdutoCommand query)
        {
            if (string.IsNullOrEmpty(query.Url))
                return BadRequest("URL Inválida.");

            var resultado = await _mediator.Send(query);

            return Ok(resultado);
        }

        /// <summary>
        /// Obter Produto por Id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("{Id}"), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Obter Produto", Description = "Obtém produto por Id.")]
        public async Task<IActionResult> ObterProduto([FromRoute] ObterProdutoQuery query)
        {
            if (query.Id < 1)
                return BadRequest("Id Inválido");

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Obter Produtos
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet(), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Obter Produtos", Description = "Obtém produtos cadastrados.")]
        public async Task<IActionResult> ObterProdutos()
        {
            var result = await _mediator.Send(new ObterProdutosQuery());

            return Ok(result);
        }
    }
}
