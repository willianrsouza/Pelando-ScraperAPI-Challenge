using AutoMapper;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Domain.Entities.ProdutoContext;

namespace IGotUScraper.Application.Mapper
{
    public class AutoMapperApplicationProfile : Profile
    {
        public AutoMapperApplicationProfile()
        {
            CreateMap<Produto, ProdutoDto>()
             .ConstructUsing((src, opt) => new ProdutoDto(src.Titulo, src.Imagem, src.Preco, src.Descricao,src.UrlComplementar));
        }
    }
}
