using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IGotUScraperApi.Controllers.v1
{
    /// <summary>
    /// Controller de clientes versão 1.0
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ObterDadosProdutoController : ControllerBase
    {

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet(), MapToApiVersion("1.0")]
        public async Task<ObjectResult> ConsultarDocumentos()
        {
            var result = "Ok Funcionando, teste!";

            return Ok(result);
        }
    }
}
