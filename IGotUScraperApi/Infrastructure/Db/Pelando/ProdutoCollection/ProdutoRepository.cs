using Dapper;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.Produto;
using IGotUScraper.Infrastructure.Base;
using IGotUScraper.Infrastructure.Db.Pelando.ProdutoRepository.Models;
using System.Data;

namespace IGotUScraper.Infrastructure.Db.Pelando.ProdutoCollection
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly IConnectionFactory _connectionFactory;

        public ProdutoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        private const string SQL_OBTER_PRODUTO_POR_ID = @"SELECT 
                                                        p.ID AS Id,
                                                        p.ID_EMPRESA AS IdEmpresa,
                                                        p.TITULO AS Titulo,
                                                        p.IMAGEM AS Imagem,
                                                        p.PRECO AS Preco, 
                                                        p.DESCRICAO AS Descricao,
                                                        p.URL AS Url,
                                                        p.DT_EXTRACT AS DataExtracao
                                                        FROM PRODUTO p 
                                                        WHERE P.ID = @id";





        public const string SQL_INSERIR_PRODUTO = @"INSERT INTO produto
                                                            (ID_EMPRESA,
                                                                TITULO,
                                                                IMAGEM,
                                                                DESCRICAO,
                                                                URL,
                                                                DT_EXTRACT,
                                                                PRECO)
                                                                VALUES(
                                                                @idEmpresa,
                                                                @titulo,
                                                                @imagem, 
                                                                @descricao,
                                                                @url,
                                                                @dtExtract, 
                                                                @preco)";


        public async Task<ProdutoEntity> ObterPorId(int id)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@id", id, DbType.Int32);

            var result = await connection.QueryFirstOrDefaultAsync<ProdutoDbModel>(SQL_OBTER_PRODUTO_POR_ID, parametros);

            return new ProdutoEntity(result.Id, result?.Titulo, result?.Imagem, result?.Preco, result?.Descricao, result?.Url, result.DataExtracao);
        }

        public async Task Inserir(ProdutoEntity produto, int idEmpresa)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();
            var parametros = new DynamicParameters();

            parametros.Add("@idEmpresa", idEmpresa, DbType.Int32);
            parametros.Add("@titulo", produto.Titulo, DbType.String);
            parametros.Add("@imagem", produto.Imagem, DbType.String);
            parametros.Add("@descricao", produto.Descricao, DbType.String);
            parametros.Add("@url", produto.Url, DbType.String);
            parametros.Add("@dtExtract", DateTime.Now, DbType.DateTime);
            parametros.Add("@preco", produto.Preco, DbType.String);

            await connection.QueryAsync<int>(SQL_INSERIR_PRODUTO, parametros);
        }
    }
}
