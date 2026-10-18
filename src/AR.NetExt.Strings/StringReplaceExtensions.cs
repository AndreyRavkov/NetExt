using System.Text;

namespace AR.NetExt.Strings;

public static class StringReplaceExtensions
{
    extension(string? stringValue)
    {
        /// <summary>
        /// Replace keys to value in the current string
        /// </summary>
        /// <param name="replacements">dictionary with key-value</param>
        /// <returns>string</returns>
        public string ReplaceExt(Dictionary<string, string> replacements)
        {
            if (stringValue.IsNullOrEmptyExt())
            {
                return string.Empty;
            }

            var result = new StringBuilder(stringValue);
            foreach (var replacement in replacements)
            {
                if (!replacement.Key.IsNullOrEmptyExt())
                {
                    result = result.Replace(replacement.Key, replacement.Value);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Replace chars in a source string
        /// </summary>
        /// <param name="chars">chars to replace</param>
        /// <param name="replaceSymbol">replace symbol</param>
        /// <returns>string</returns>
        public string ReplaceCharsExt(char[] chars, string replaceSymbol = "")
        {
            if (stringValue.IsNullOrEmptyExt())
            {
                return stringValue ?? string.Empty;
            }

            var result = new StringBuilder(stringValue);
            foreach (var c in chars)
            {
                result.Replace(c.ToString(), replaceSymbol);
            }

            return result.ToString();
        }

        /// <summary>
        /// Replace chars in a source string
        /// </summary>
        /// <param name="chars">string of chars to replace</param>
        /// <param name="replaceSymbol">replace symbol</param>
        /// <returns>string</returns>
        public string ReplaceCharsExt(string chars, string replaceSymbol = "")
        {
            return ReplaceCharsExt(stringValue, chars.ToCharArray(), replaceSymbol);
        }
    }
}