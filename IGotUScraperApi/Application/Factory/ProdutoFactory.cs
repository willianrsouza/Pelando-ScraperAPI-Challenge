using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;

namespace IGotUScraper.Application.Factory
{
    public abstract class ProdutoFactory
    {
        public ProdutoDto FabricarProduto(string url)
        {
            ProdutoDto produto;
            produto = ObterDados(url);

            return produto;
        }

        public abstract ProdutoDto ObterDados(string url);
    }
}
