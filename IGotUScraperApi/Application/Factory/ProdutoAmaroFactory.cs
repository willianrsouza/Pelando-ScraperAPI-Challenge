using HtmlAgilityPack;
using IGotUScraper.Application.Factory.Dto;

namespace IGotUScraper.Application.Factory
{
    public class ProdutoAmaroFactory : ScraperFactory
    {
        private readonly HtmlWeb _htmlWeb;
        private ProdutoFactoryDto _produto;

        public ProdutoAmaroFactory() 
        {
            _htmlWeb  = new HtmlWeb();
            _produto = new ProdutoFactoryDto(); 
        }

        public ProdutoFactoryDto obterDadosProduto(string url)
        {
            construirValoresProduto(url);
            construirDescricaoProduto(url);
            _produto.UrlBase = url;

            return _produto;
        }

        private void construirValoresProduto(string url)
        {
            var doc = _htmlWeb.Load(url);
            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"productOptions\"]");

            foreach (var item in valoresProduto)
            {
                _produto.Titulo = item.SelectSingleNode("//*[@id=\"productOptions\"]/h1").InnerText;
                _produto.Preco = item.SelectSingleNode("//*[@id=\"productOptions\"]/div[3]/div[1]/strong").InnerText;
            }
        }

        private void construirDescricaoProduto(string url)
        {
            var doc = _htmlWeb.Load(url);

            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"__next\"]/div[1]/div[4]");

            foreach (var item in valoresProduto)
            {
                _produto.Descricao = item.SelectSingleNode("/html/body/div/div[1]/div[4]/div[2]/div[1]/div[1]/div/section/div/p[1]/text()").InnerText;
            }
        }
    }
}
