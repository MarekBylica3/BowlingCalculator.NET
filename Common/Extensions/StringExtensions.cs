using System.Text.RegularExpressions;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all whitespace characters from a string input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveWhitespace(this string input)
        {
            return Regex.Replace(input, @"\s+", string.Empty);
        }
    }
}
