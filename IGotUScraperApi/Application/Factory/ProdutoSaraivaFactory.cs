using HtmlAgilityPack;
using IGotUScraper.Application.Factory.Dto;

namespace IGotUScraper.Application.Factory
{
    internal class ProdutoSaraivaFactory : ProdutoFactory
    {
        private readonly HtmlWeb _htmlWeb;
        private FactoryDto _factoryDto;

        public ProdutoSaraivaFactory()
        {
            _htmlWeb = new HtmlWeb();
            _factoryDto = new FactoryDto();
        }

        protected override FactoryDto ObterDados(string url)
        {
            var document = _htmlWeb.Load(url);

            construirValoresProduto(document);
            construirDescricaoProduto(document);

            return _factoryDto;
        }

        private void construirValoresProduto(HtmlDocument document)
        {
            var valoresProduto = document.DocumentNode
                .SelectNodes(xpath: "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div");

            foreach (var item in valoresProduto)
            {
                _factoryDto.Titulo = item.SelectSingleNode("/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div/div/div[1]/div/div/div/h1/span").InnerText;
                _factoryDto.Preco = item.SelectSingleNode("/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div/div/div[4]/div/div/div[1]/div/div/div[2]/span/span/span").InnerText;
            }
        }

        private void construirDescricaoProduto(HtmlDocument document)
        {
            var result = document.DocumentNode
                .SelectNodes(xpath: "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[3]/section/div/div");

            foreach (var item in result)
            {
                _factoryDto.Descricao = item.SelectSingleNode("/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[3]/section/div/div/div/div/div/div[1]/div/text()").InnerText;
            }
        }
    }
}
