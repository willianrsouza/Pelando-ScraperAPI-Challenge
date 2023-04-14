using HtmlAgilityPack;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace IGotUScraper.Utilities
{
    public static class ExtrairDados
    {
        public static string ObterNomeProduto(string caminho, int segmento)
        {
            var uri = new UriBuilder(caminho).Uri;
            var capturarSegmento = uri.Segments[segmento];

            return capturarSegmento.Replace("-", " ").Replace("/", "").ToLower();
        }

        public static string ObterNomeEmpresa(string caminho)
        {
            var url = new UriBuilder(caminho).Uri.Host;

            return TratarDados.LimparCaracteres(url);
        }

        public static string Imagem(HtmlDocument html, string box, string SectionUm, string SectionDois)
        {
            string? result = "Não foi possivel localizar.";

             result = html.DocumentNode.SelectNodes(xpath: box).Descendants(SectionUm)
                               .Select(e => e.GetAttributeValue(SectionDois, null))
                               .Where(s => !String.IsNullOrEmpty(s)).FirstOrDefault();
            return result;
        }

        public static string InnerText(HtmlDocument html, string caminhoPrimario, string caminhoSecundario)
        {
            var sections = html.DocumentNode.SelectNodes(xpath: caminhoPrimario);

            string? result = "Não foi possivel localizar.";

            foreach (var item in sections)
            {
                result = item.SelectSingleNode(caminhoSecundario).InnerText;
            }

            return result;
        }

    }
}
