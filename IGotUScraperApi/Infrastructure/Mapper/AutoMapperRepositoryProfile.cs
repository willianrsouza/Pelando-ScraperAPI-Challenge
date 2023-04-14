
using AutoMapper;
using IGotUScraper.Domain.Entities.EmpresaContext;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Infrastructure.Db.Pelando.Empresa.Models;
using IGotUScraper.Infrastructure.Db.Pelando.ProdutoRepository.Models;

namespace IGotUScraper.Infrastructure.Mapper
{
    public class AutoMapperRepositoryProfile : Profile
    {
        public AutoMapperRepositoryProfile()
        {
            CreateMap<ProdutoDbModel, ProdutoEntity>()
             .ConstructUsing((src, opt) => new ProdutoEntity(0, src.Titulo, src.Imagem, src.Preco, src.Descricao, src.Url, src.DataExtracao));

            CreateMap<EmpresaDbModel, EmpresaEntity>()
            .ConstructUsing((src, opt) => new EmpresaEntity(src.Id, src?.Nome, src?.UrlBase));
        }
    }
}
