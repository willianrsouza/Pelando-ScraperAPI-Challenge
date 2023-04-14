using IGotUScraper.Domain.Entities.ProdutoContext;

namespace IGotUScraper.Domain.Interfaces.Repositories.Database.Produto
{
    public interface IProdutoRepository
    {
        Task Inserir(ProdutoEntity produto, int idEmpresa);
        Task<ProdutoEntity> ObterPorId(int id);
        Task<IEnumerable<ProdutoEntity>> ObterProdutos();
        Task<ProdutoEntity> ObterProdutoPorUrl(string url);
    }
}
