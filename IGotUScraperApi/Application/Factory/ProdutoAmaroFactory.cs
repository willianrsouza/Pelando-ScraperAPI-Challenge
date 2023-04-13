using HtmlAgilityPack;
using IGotUScraper.Application.Factory.Dto;

namespace IGotUScraper.Application.Factory
{
    public class ProdutoAmaroFactory : ProdutoFactory
    {
        private readonly HtmlWeb _htmlWeb;
        private FactoryDto _factoryDto;

        public ProdutoAmaroFactory()
        {
            _htmlWeb = new HtmlWeb();
            _factoryDto = new FactoryDto();
        }

        protected override FactoryDto ObterDados(string url)
        {
            construirValoresProduto(url);
            construirDescricaoProduto(url);

            return _factoryDto;
        }

        private void construirValoresProduto(string url)
        {
            var doc = _htmlWeb.Load(url);
            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"productOptions\"]");

            foreach (var item in valoresProduto)
            {
                _factoryDto.Titulo = item.SelectSingleNode("//*[@id=\"productOptions\"]/h1").InnerText;
                _factoryDto.Preco = item.SelectSingleNode("//*[@id=\"productOptions\"]/div[3]/div[1]/strong").InnerText;
            }
        }

        private void construirDescricaoProduto(string url)
        {
            var doc = _htmlWeb.Load(url);

            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"__next\"]/div[1]/div[4]");

            foreach (var item in valoresProduto)
            {
                _factoryDto.Descricao = item.SelectSingleNode("/html/body/div/div[1]/div[4]/div[2]/div[1]/div[1]/div/section/div/p[1]/text()").InnerText;
            }
        }
    }
}
