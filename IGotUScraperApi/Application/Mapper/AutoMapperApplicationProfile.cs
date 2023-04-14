using AutoMapper;
using IGotUScraper.Application.Handlers.EmpresaHandlers.Dto;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Domain.Entities.EmpresaContext;
using IGotUScraper.Domain.Entities.ProdutoContext;
using System.Diagnostics.CodeAnalysis;

namespace IGotUScraper.Application.Mapper
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperApplicationProfile : Profile
    {
        public AutoMapperApplicationProfile()
        {
            CreateMap<ProdutoEntity, ProdutoDto>()
             .ConstructUsing((src, opt) => new ProdutoDto(src.Titulo, src.Imagem, src.Preco, src.Descricao, src.Url));

            CreateMap<EmpresaEntity, EmpresaDto>()
              .ConstructUsing((src, opt) => new EmpresaDto(src.Id, src.Nome, src.UrlBase));

            CreateMap<ProdutoDto, ProdutoEntity>()
             .ConstructUsing((src, opt) => new ProdutoEntity(0, src?.Titulo, src?.Imagem, src.Preco, src?.Descricao, src?.Url, DateTime.Now));
        }
    }
}
