using HtmlAgilityPack;
using IGotUScraper.Application.Handlers.ProdutoHandlers.Dto;
using IGotUScraper.Utilities;

namespace IGotUScraper.Application.Factory
{
    public class ProdutoSaraivaFactory : ProdutoFactory
    {
        private readonly HtmlWeb _htmlWeb;
        private ProdutoDto _produtoDto;

        public ProdutoSaraivaFactory()
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
            _produtoDto.Titulo = ExtrairDados.InnerText(html, "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div", "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div/div/div[1]/div/div/div/h1/span");
            _produtoDto.Preco = ExtrairDados.InnerText(html, "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div", "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div/div/div[4]/div/div/div[1]/div/div/div[2]");
            _produtoDto.Descricao = ExtrairDados.InnerText(html, "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[3]/section", "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[3]/section/div/div/div/div/div/div[1]/div/text()");
            _produtoDto.Imagem = ExtrairDados.Imagem(html, "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[1]", "img", "src");
            _produtoDto.Url = url;
        }
    }
}
