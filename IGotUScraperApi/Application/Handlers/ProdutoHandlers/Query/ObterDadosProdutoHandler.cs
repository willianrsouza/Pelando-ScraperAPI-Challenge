using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using MediatR;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query
{
    public class ObterDadosProdutoHandler : IRequestHandler<ObterDadosProdutoQuery, ProdutoDto>
    {
        public Task<ProdutoDto> Handle(ObterDadosProdutoQuery request, CancellationToken cancellationToken)
        {
            var produto = new ProdutoDto("Playstation 5", 10, "Console");

            return Task.FromResult(produto);
        }
    }
}
