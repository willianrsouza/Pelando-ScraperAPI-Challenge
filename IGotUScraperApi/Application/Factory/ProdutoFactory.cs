using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;

namespace IGotUScraper.Application.Factory
{
    public abstract class ProdutoFactory
    {
        public ProdutoDto MontarProduto(string url)
        {
            ProdutoDto produto;
            produto = ObterDados(url);

            return produto;
        }

        protected abstract ProdutoDto ObterDados(string url);
    }
}
