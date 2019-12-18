using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Util
{
    public static class Extends
    {
        public static string RemoveAcentos(this string texto)
        {
            texto = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in texto)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString();
        }

        public static string RemoveCaracterEspeciais(this string texto, string substituicao = "-")
        {
            return texto == null ? null : Regex.Replace(texto, "[^0-9a-zA-Z]+?", substituicao);
        }
    }
}
