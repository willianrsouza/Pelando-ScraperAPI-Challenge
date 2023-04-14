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

        public EmpresaRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        private const string SQL_OBTER_EMPRESA_POR_ID = @"SELECT 
                                                        e.ID AS Id,
                                                        e.NOME AS Nome,
                                                        e.URL_BASE AS UrlBase
                                                        FROM EMPRESA e 
                                                        WHERE e.ID = @id";

        private const string SQL_OBTER_PRODUTO_POR_ID = @"SELECT 
                                                        p.ID AS Id,
                                                        p.ID_EMPRESA AS IdEmpresa,
                                                        p.TITULO AS Titulo,
                                                        p.IMAGEM AS Imagem,
                                                        p.PRECO AS Preco, 
                                                        p.DESCRICAO AS Descricao,
                                                        p.URL_COMPLEMENTAR AS UrlComplementar,
                                                        p.DT_EXTRACT AS DataExtracao
                                                        FROM PRODUTO p 
                                                        WHERE P.ID = @id";
        public async Task<EmpresaEntity> ObterEmpresa(int id)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@id", id, DbType.Int32);

            var result = await connection.QueryFirstOrDefaultAsync<EmpresaDbModel>(SQL_OBTER_EMPRESA_POR_ID, parametros);

            return new EmpresaEntity(result.Id, result.Nome, result.UrlBase);
        }
  
    }
}
