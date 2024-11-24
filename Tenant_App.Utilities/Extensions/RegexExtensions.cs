using System.Text.RegularExpressions;

namespace Tenant_App.Utilities.Extensions
{
    public static class RegexExtensions
    {
        private static readonly Regex Whitespace = new Regex(@"\s+");

        public static string ReplaceWhitespace(this string input, string replacement)
        {
            return Whitespace.Replace(input, replacement);
        }
    }
}