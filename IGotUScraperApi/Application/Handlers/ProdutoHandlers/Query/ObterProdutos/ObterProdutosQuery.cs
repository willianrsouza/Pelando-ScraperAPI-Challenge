using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query.ObterProduto
{
    public record ObterProdutosQuery() : IRequest<IEnumerable<ProdutoDto>>;
}
