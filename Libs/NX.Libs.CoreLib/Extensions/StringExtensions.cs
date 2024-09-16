using System.Text;

namespace NX.Libs.CoreLib.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharacterUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            string[] words = str.ToLower().Split(' ');
            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {
                if (word.Length > 0)
                    sb.Append(char.ToUpper(word[0]) + word.Substring(1) + " ");
            }

            return sb.ToString().Trim();
        }

        public static string RemoveWhitespace(this string str)
        {
            if (str == null) return string.Empty;

            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
