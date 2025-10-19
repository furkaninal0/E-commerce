using System.Text.RegularExpressions;

namespace MVCEcommerce;

public static class AppExtensions
{
    public static string ToSafeUrlString(this string text) => Regex.Replace(string.Concat(text.Where(p =>
    char.IsWhiteSpace(p) || char.IsLetterOrDigit(p))).ToLower(), @"\s+", "-");
    

}
