using HtmlAgilityPack;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Utilities;

namespace IGotUScraper.Application.Factory
{
    public class ProdutoAmaroFactory : ProdutoFactory
    {
        private readonly HtmlWeb _htmlWeb;
        private ProdutoDto _produtoDto;

        public ProdutoAmaroFactory()
        {
            _htmlWeb = new HtmlWeb();
            _produtoDto = new ProdutoDto();
        }

        protected override ProdutoDto ObterDados(string url)
        {
            construirValoresProduto(url);
            construirDescricaoProduto(url);

            return _produtoDto;
        }

        private void construirValoresProduto(string url)
        {
            var doc = _htmlWeb.Load(url);
            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"productOptions\"]");

            foreach (var item in valoresProduto)
            {
                _produtoDto.Titulo = item.SelectSingleNode("//*[@id=\"productOptions\"]/h1").InnerText;
                _produtoDto.Preco = TratarDados.SomenteNumero(item.SelectSingleNode("//*[@id=\"productOptions\"]/div[3]/div[1]/strong").InnerText);
            }
        }

        private void construirDescricaoProduto(string url)
        {
            var doc = _htmlWeb.Load(url);

            var valoresProduto = doc.DocumentNode.SelectNodes(xpath: "//*[@id=\"__next\"]/div[1]/div[4]");

            foreach (var item in valoresProduto)
            {
                _produtoDto.Descricao = item.SelectSingleNode("/html/body/div/div[1]/div[4]/div[2]/div[1]/div[1]/div/section/div/p[1]/text()").InnerText;
            }
        }
    }
}
