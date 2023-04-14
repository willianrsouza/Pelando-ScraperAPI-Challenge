using HtmlAgilityPack;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Utilities;
using System.Reflection.Metadata;

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

        public override ProdutoDto ObterDados(string url)
        {
            var document = _htmlWeb.Load(url);

            obterValoresProduto(document);
            obterDescricaoProduto(document);
            obterImagemProduto(document);

            _produtoDto.Url = url;

            return _produtoDto;
        }

        private void obterValoresProduto(HtmlDocument document)
        {
            var sections = document.DocumentNode.SelectNodes(xpath: "//*[@id=\"productOptions\"]");

            foreach (var item in sections)
            {
                _produtoDto.Titulo = item.SelectSingleNode("//*[@id=\"productOptions\"]/h1").InnerText;
                _produtoDto.Preco = TratarDados.SomenteNumero(item.SelectSingleNode("//*[@id=\"productOptions\"]/div[3]/div[1]/strong").InnerText);
            }
        }

        private void obterDescricaoProduto(HtmlDocument document)
        {
            var sections = document.DocumentNode.SelectNodes(xpath: "//*[@id=\"__next\"]/div[1]/div[4]");

            foreach (var item in sections)
            {
                _produtoDto.Descricao = item.SelectSingleNode("/html/body/div/div[1]/div[4]/div[2]/div[1]/div[1]/div/section/div/p[1]/text()").InnerText;
            }
        }

        private void obterImagemProduto(HtmlDocument document)
        {
            var node = document.DocumentNode.SelectNodes(xpath: "//*[@id=\"__next\"]/div[1]/div[3]");

            _produtoDto.Imagem = ExtrairDados.ImagemSite(node, "img", "srcset");
        }
    }
}
