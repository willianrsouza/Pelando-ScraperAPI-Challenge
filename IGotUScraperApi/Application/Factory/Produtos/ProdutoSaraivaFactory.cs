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
            var document = _htmlWeb.Load(url);

            obterValoresProduto(document);
            obterDescricaoProduto(document);
            obterImagemProduto(document);

            _produtoDto.Url = url;

            return _produtoDto;
        }

        private void obterValoresProduto(HtmlDocument document)
        {
            var valoresProduto = document.DocumentNode
                .SelectNodes(xpath: "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div");

            foreach (var item in valoresProduto)
            {
                _produtoDto.Titulo = item.SelectSingleNode("/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div/div/div[1]/div/div/div/h1/span").InnerText;
                _produtoDto.Preco = TratarDados.SomenteNumero(item.SelectSingleNode("/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[2]/section/div/div[2]/div/div/div/div[4]/div/div/div[1]/div/div/div[2]/span/span/span").InnerText);
            }
        }

        private void obterDescricaoProduto(HtmlDocument document)
        {
            var result = document.DocumentNode
                .SelectNodes(xpath: "/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[3]/section/div/div");

            foreach (var item in result)
            {
                _produtoDto.Descricao = item.SelectSingleNode("/html/body/div[2]/div/div[1]/div/div/div/div[4]/div/div[1]/div[3]/section/div/div/div/div/div/div[1]/div/text()").InnerText;
            }
        }

        private void obterImagemProduto(HtmlDocument document)
        {
            var node = document.DocumentNode.SelectNodes(xpath: "/html/body/div[2]/div/div[1]/div/div/div/div[2]/div/div[2]/div[2]/section/div/div[1]/div/div/div/div[1]/div/div/div[1]/div/div/div[2]/div");
            
            _produtoDto.Imagem = ExtrairDados.ImagemSite(node, "img", "src");
        }
    }
}
