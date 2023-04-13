using IGotUScraper.Application.Factory.Dto;

namespace IGotUScraper.Application.Factory
{
    public abstract class ProdutoFactory
    {
        public FactoryDto MontarProduto(string url)
        {
            FactoryDto produto;
            produto = ObterDados(url);

            return produto;
        }

        protected abstract FactoryDto ObterDados(string url);
    }
}
