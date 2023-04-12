using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Utilities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query
{
    public class ObterDadosProdutoHandler : IRequestHandler<ObterDadosProdutoQuery, ProdutoDto>
    {
        private readonly ScraperFactory _produtoAmazonFactory;
        private readonly ILogger<ObterDadosProdutoHandler> _logger;

        public ObterDadosProdutoHandler(ILogger<ObterDadosProdutoHandler> logger)
        {
            _produtoAmazonFactory = new ProdutoAmaroFactory();
            _logger = logger;
        }

        public Task<ProdutoDto> Handle(ObterDadosProdutoQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando Handler.");

           // var nomeProduto = ExtrairDadosPath.ObterNomeProduto(request.Url, 8);

            var teste = ExtrairDadosPath.ObterCaminhoBase(request.Url);

            _produtoAmazonFactory.obterDadosProduto(request.Url);
            var result = _produtoAmazonFactory.result();

            var produto = new ProdutoDto(result?.Titulo, result?.Preco, result?.Descricao, result?.Url);

            _logger.LogInformation("Finalizando Handler.");

            return Task.FromResult(produto);
        }
    }
}
