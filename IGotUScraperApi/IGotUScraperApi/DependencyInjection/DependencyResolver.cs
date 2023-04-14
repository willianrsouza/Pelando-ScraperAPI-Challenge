using AutoMapper;
using IGotUScraper.Application.Mapper;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using IGotUScraper.Infrastructure.Base;
using IGotUScraper.Infrastructure.Db.Pelando.EmpresaCollection;
using IGotUScraper.Infrastructure.Db.Pelando.ProdutoCollection;
using IGotUScraper.Infrastructure.Mapper;

namespace IGotUScraperApi.DependencyInjection
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services)
        {
            RegisterCommonTypes(services);
            RegisterRepositories(services);
            RegisterInfrastructureTypes(services);
            RegisterAutoMapper(services);
        }

        /// <summary>
        /// Realizando a Injeção de Dependencia 
        /// Contexto: CommonTypes
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterCommonTypes(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }


        private static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperApplicationProfile());
                cfg.AddProfile(new AutoMapperRepositoryProfile());

            }).CreateMapper());
        }


        /// <summary>
        ///  Realizando a Injeção de Dependencia (Responsavel pela Inversão de Controle)
        /// Contexto: Infrastructure
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterInfrastructureTypes(IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
        }

        /// <summary>
        /// Realizando a Injeção de Dependencia (Responsavel pela Inversão de Controle)
        /// Contexto: Repository
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }
    }
}
