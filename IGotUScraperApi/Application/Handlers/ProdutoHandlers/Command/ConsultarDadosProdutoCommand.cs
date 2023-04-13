using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace IGotUScraper.Application.Handlers.ProdutoHandlers.Command
{
    public record ConsultarDadosProdutoCommand([property: SwaggerSchema("Url do Produto")] string Url) : IRequest<ProdutoDto>;
}
