using HtmlAgilityPack;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

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

        public static string ImagemSite(HtmlNodeCollection node, string SectionUm, string SectionDois)
        {
            var result = node.Descendants(SectionUm)
                               .Select(e => e.GetAttributeValue(SectionDois, null))
                               .Where(s => !String.IsNullOrEmpty(s)).FirstOrDefault();

           return string.IsNullOrEmpty(result) ? "N/P" : result;
        }

    }
}
