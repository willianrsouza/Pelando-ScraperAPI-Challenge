using AutoMapper;
using Dapper;
using IGotUScraper.Domain.Base;
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
        private readonly IMapper _mapper;

        public ProdutoRepository(IConnectionFactory connectionFactory, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _mapper = mapper;
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



        private const string SQL_OBTER_PRODUTO_ATUALIZADO = @"SELECT 
                                                            p.TITULO AS Titulo, 
                                                            p.IMAGEM As Imagem,
                                                            p.PRECO AS Preco, 
                                                            p.DESCRICAO AS Descricao, 
                                                            p.URL AS Url
                                                            FROM PRODUTO p
                                                            WHERE p.URL LIKE @url
                                                            AND p.DT_EXTRACT < @datenow - INTERVAL 1 HOUR";


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

            return _mapper.Map<ProdutoEntity>(result);
        }

        public async Task<ProdutoEntity> ObterProdutoPorUrl(string url)
        {
            using var connection = _connectionFactory.CreatePelandoDbConnection();
            var parametros = new DynamicParameters();

            parametros.Add("@url", url, DbType.Int32);
            parametros.Add("@datenow", DateTime.Now, DbType.DateTime);

            var result = await connection.QueryFirstOrDefaultAsync<ProdutoDbModel>(SQL_OBTER_PRODUTO_ATUALIZADO, parametros);

            return _mapper.Map<ProdutoEntity>(result);  
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
