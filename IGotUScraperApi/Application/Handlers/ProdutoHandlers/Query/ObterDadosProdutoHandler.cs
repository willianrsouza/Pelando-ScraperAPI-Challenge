using IGotUScraper.Application.Factory;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using MediatR;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query
{
    public class ObterDadosProdutoHandler : IRequestHandler<ObterDadosProdutoQuery, ProdutoDto>
    {
        private readonly ScraperFactory _produtoAmazonFactory;

        public ObterDadosProdutoHandler() 
        {
            _produtoAmazonFactory = new ProdutoAmaroFactory();
        }

        public Task<ProdutoDto> Handle(ObterDadosProdutoQuery request, CancellationToken cancellationToken)
        {
            _produtoAmazonFactory.obterDadosProduto(request.Url);
            var result = _produtoAmazonFactory.result();

            var produto = new ProdutoDto(result?.Titulo, result?.Preco, result.Descricao, result.Url);

            return Task.FromResult(produto);
        }
    }
}
