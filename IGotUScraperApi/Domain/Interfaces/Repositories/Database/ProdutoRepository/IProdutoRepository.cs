using IGotUScraper.Domain.Entities.ProdutoContext;

namespace IGotUScraper.Domain.Interfaces.Repositories.Database.ProdutoRepository
{
    public interface IProdutoRepository
    {
        Task<Produto> ObterPorId(int id);
    }
}
