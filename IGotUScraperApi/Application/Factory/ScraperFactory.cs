using IGotUScraper.Application.Factory.Dto;

namespace IGotUScraper.Application.Factory
{
    public abstract class ScraperFactory
    {
        protected ProdutoFactoryDto ProdutoFactory = new ProdutoFactoryDto();

        public abstract void obterDadosProduto(string url);

        public ProdutoFactoryDto result()
        {
            return ProdutoFactory;
        }
    }
}
