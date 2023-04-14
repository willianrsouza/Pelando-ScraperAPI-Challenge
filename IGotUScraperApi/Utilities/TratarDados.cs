using System.Text.RegularExpressions;

namespace IGotUScraper.Utilities
{
    public static class TratarDados
    {
        public static string SomenteNumero(string input)
        {
            string result = String.Join("", Regex.Split(input, @"[R$]"))
                .Replace(input, "").Trim();

            return result;
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
