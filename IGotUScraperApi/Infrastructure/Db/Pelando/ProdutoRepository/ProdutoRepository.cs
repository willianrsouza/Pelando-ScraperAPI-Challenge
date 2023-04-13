using Dapper;
using IGotUScraper.Domain.Entities.ProdutoContext;
using IGotUScraper.Domain.Interfaces.Repositories.Database.ProdutoRepository;
using IGotUScraper.Infrastructure.Base;
using IGotUScraper.Infrastructure.Db.Pelando.ProdutoRepository.Models;
using System.Data;

namespace IGotUScraper.Infrastructure.Db.Pelando.ProdutoRepository
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
                                                        p.URL_COMPLEMENTAR AS UrlComplementar,
                                                        p.DT_EXTRACT AS DataExtracao
                                                        FROM PRODUTO p 
                                                        WHERE P.ID = @id";



        public async Task<Produto> ObterPorId(int id)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@id", id, DbType.Int32);

            var result = await connection.QueryFirstOrDefaultAsync<ProdutoDbModel>(SQL_OBTER_PRODUTO_POR_ID, parametros);

            return new Produto(result.Id, result.Titulo, result.Imagem, result.Preco, result.Descricao, result.UrlComplementar, result.DataExtracao); 
        }  
    } 
}
 