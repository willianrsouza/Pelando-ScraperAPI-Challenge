using HtmlAgilityPack;

namespace IGotUScraper.Application.Factory
{
    public class ProdutoAmaroFactory : ScraperFactory
    {
        private readonly HtmlWeb _htmlWeb;

        public ProdutoAmaroFactory()
        {
            _htmlWeb = new HtmlWeb();
        }

        public override void obterDadosProduto(string url)
        {
            obterValoresProduto(url);
            obterDescricaoProduto(url);

            ProdutoFactory.Url = url;
        }

        public void obterValoresProduto(string url)
        {
            var doc = _htmlWeb.Load(url);
            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"productOptions\"]");

            foreach (var item in valoresProduto)
            {
                ProdutoFactory.Titulo = item.SelectSingleNode("//*[@id=\"productOptions\"]/h1").InnerText;
                ProdutoFactory.Preco = item.SelectSingleNode("//*[@id=\"productOptions\"]/div[3]/div[1]/strong").InnerText;
            }
        }

        public void obterDescricaoProduto(string url)
        {
            var doc = _htmlWeb.Load(url);

            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"__next\"]/div[1]/div[4]");

            foreach (var item in valoresProduto)
            {
                ProdutoFactory.Descricao = item.SelectSingleNode("/html/body/div/div[1]/div[4]/div[2]/div[1]/div[1]/div/section/div/p[1]/text()").InnerText;
            }
        }
    }
}
