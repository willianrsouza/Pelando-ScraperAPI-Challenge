using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Query
{
    public record ObterProdutoQuery([property: SwaggerSchema("Id Produto")]int Id) : IRequest<ProdutoDto>;
}
