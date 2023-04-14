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

        public override ProdutoDto ObterDados(string url)
        {
            var html = _htmlWeb.Load(url);
            ConstruirProduto(html, url);

            return _produtoDto;
        }

        private void ConstruirProduto(HtmlDocument html, string url)
        {
            _produtoDto.Titulo = ExtrairDados.InnerText(html, "//*[@id=\"productOptions\"]", "//*[@id=\"productOptions\"]/h1");
            _produtoDto.Imagem = ExtrairDados.Imagem(html, "//*[@id=\"__next\"]/div[1]/div[3]/div[2]/div[2]/div[1]", "img", "srcset");
            _produtoDto.Preco = ExtrairDados.InnerText(html, "//*[@id=\"productOptions\"]", "//*[@id=\"productOptions\"]/div[3]/div[1]/strong");
            _produtoDto.Descricao = ExtrairDados.InnerText(html, "//*[@id=\"__next\"]/div[1]/div[4]", "/html/body/div/div[1]/div[4]/div[2]/div[1]/div[1]/div/section/div/p[1]/text()");
            _produtoDto.Url = url;
        }
    }
}
