using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Factory.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Utilities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query
{
    public class ObterDadosProdutoHandler : IRequestHandler<ObterDadosProdutoQuery, ProdutoDto>
    {
        private readonly ILogger<ObterDadosProdutoHandler> _logger;

        public ObterDadosProdutoHandler(ILogger<ObterDadosProdutoHandler> logger)
        {
            _logger = logger;
        }

        public Task<ProdutoDto> Handle(ObterDadosProdutoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler.");

            var empresa = ExtrairDadosPath.ObterNomeEmpresa(request.Url);

            ProdutoFactory factory = SimpleProdutoFactory.ObterFactory("saraiva");

            var produto = factory.MontarProduto(request.Url);

            var result = MapearProduto(produto);

            _logger.LogInformation("Finalizando Handler.");

            return Task.FromResult(result);
        }

        private ProdutoDto MapearProduto(FactoryDto factoryDto) 
        {
            var produtoDto = new ProdutoDto(factoryDto.Titulo, factoryDto.Preco, factoryDto.Descricao, factoryDto.UrlBase);
          
            return produtoDto;
        }
    }
}
