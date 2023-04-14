using AutoMapper;
using Dapper;
using IGotUScraper.Domain.Entities.EmpresaContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Empresa;
using IGotUScraper.Infrastructure.Base;
using IGotUScraper.Infrastructure.Db.Pelando.Empresa.Models;
using IGotUScraper.Infrastructure.Db.Pelando.ProdutoRepository.Models;
using System.Data;

namespace IGotUScraper.Infrastructure.Db.Pelando.EmpresaCollection
{
    public class EmpresaRepository : IEmpresaRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        private readonly IMapper _mapper;
        public EmpresaRepository(IConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
        }

        private const string SQL_OBTER_EMPRESA_POR_ID = @"SELECT 
                                                        e.ID AS Id,
                                                        e.NOME AS Nome,
                                                        e.URL_BASE AS UrlBase
                                                        FROM EMPRESA e 
                                                        WHERE e.ID = @id";


        public async Task<EmpresaEntity> ObterEmpresa(int id)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@id", id, DbType.Int32);

            var result = await connection.QueryFirstOrDefaultAsync<EmpresaDbModel>(SQL_OBTER_EMPRESA_POR_ID, parametros);

            return _mapper.Map<EmpresaEntity>(result);
        }
    }
}
