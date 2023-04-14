using System.Text.RegularExpressions;

namespace IGotUScraper.Utilities
{
    public static class ExtrairDadosPath
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

            return LimparCaracteres(url);
        }

        public static string ObterCaminhoBase(string caminho)
        {
            var uri = new UriBuilder(caminho).Uri;

            return uri.Authority;
        }

        public static string LimparCaracteres(string caracteres) 
        {
            return Regex.Replace(caracteres, @"[^/A-z]+", String.Empty)
                .Replace("w", "")
                .Replace("com", "")
                .Replace("br", ""); 
        }
    }
}
