using AutoMapper;
using Dapper;
using IGotUScraper.Domain.Entities.EmpresaContext;
using IGotUScraper.Domain.Entities.ProdutoContext;
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

        private const string SQL_OBTER_EMPRESA_POR_NOME = @"SELECT 
                                                        e.ID AS Id,
                                                        e.NOME AS Nome,
                                                        e.URL_BASE AS UrlBase
                                                        FROM EMPRESA e 
                                                        WHERE e.NOME = @nome";

        private const string SQL_OBTER_EMPRESAS = @"SELECT 
                                                        e.ID AS Id,
                                                        e.NOME AS Nome,
                                                        e.URL_BASE AS UrlBase
                                                        FROM EMPRESA e";


        public async Task<EmpresaEntity> ObterEmpresa(int id)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@id", id, DbType.Int32);

            var result = await connection.QueryFirstOrDefaultAsync<EmpresaDbModel>(SQL_OBTER_EMPRESA_POR_ID, parametros);

            return _mapper.Map<EmpresaEntity>(result);
        }

        public async Task<EmpresaEntity> ObterEmpresaPorNome(string nome)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@nome", nome, DbType.String);

            var result = await connection.QueryFirstOrDefaultAsync<EmpresaDbModel>(SQL_OBTER_EMPRESA_POR_NOME, parametros);

            return _mapper.Map<EmpresaEntity>(result);
        }


        public async Task<IEnumerable<EmpresaEntity>> ObterEmpresas()
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();

            return _mapper.Map<IEnumerable<EmpresaEntity>>(await connection.QueryAsync<EmpresaDbModel>(SQL_OBTER_EMPRESAS));
        }

    }
}
