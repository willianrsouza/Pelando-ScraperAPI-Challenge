using IGotUScraper.Application.Factory.Dto;

namespace IGotUScraper.Application.Factory
{
    public interface ScraperFactory
    {
        public abstract void obterDadosProduto(string url);
    }
}
