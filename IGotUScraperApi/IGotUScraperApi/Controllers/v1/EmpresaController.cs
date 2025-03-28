﻿using IGotUScraper.Application.Handlers.EmpresaHandlers.Query.ObterEmpresa;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IGotUScraperApi.Controllers.v1
{
    /// <summary>
    /// Controller da Empresa
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IMediator _mediator;


        public EmpresaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obter Empresa por Id
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("{Id}"), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Obter Empresa Por Id", Description = "Obtém empresa cadastrada por Id.")]
        public async Task<IActionResult> ObterEmpresa([FromRoute] ObterEmpresaQuery query)
        {
            if(query.Id < 1)
              return BadRequest("Id Inválido");

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Obter Empresas Cadastradas 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet(), MapToApiVersion("1.0")]
        [SwaggerOperation(Summary = "Obter Empresas", Description = "Obtém empresas cadastradas")]
        public async Task<IActionResult> ObterEmpresas()
        {
            var result = await _mediator.Send(new ObterEmpresasQuery());

            return Ok(result);
        }
    }
}
  