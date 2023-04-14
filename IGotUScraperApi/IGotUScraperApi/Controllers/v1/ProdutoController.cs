using IGotUScraper.Application.Handlers.ProdutoHandlers.Command;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto;
using IGotUScraper.Domain.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Internal;
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
        /// Consultar - Cadastras Produto Por 'URL' 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpPost(), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Consultar - Cadastras Produto", Description = "Consultar - Cadastras dados de um produto.")]
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
  