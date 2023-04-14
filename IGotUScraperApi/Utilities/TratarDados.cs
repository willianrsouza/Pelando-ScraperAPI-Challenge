
using System.Globalization;
using System.Text.RegularExpressions;

namespace IGotUScraper.Utilities
{
    public static class TratarDados
    {
        public static string SomenteNumero(string input) 
        {
            string result = String.Join("", Regex.Split(input, @"[R$]"))
                .Replace(input, "").Trim();

            //var converter = Double.Parse(result);

            return result;
        }

    }
}
