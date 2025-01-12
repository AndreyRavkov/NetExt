using System.Globalization;
using System.Text;

namespace NetExt.Core.Strings;

public static class StringsExtensions
{
    public static bool HasMaxLengthExt(this string? str,
                                 int maxLength, 
                                 Action? onNegativeAction = null)
    {
        str = str?.TrimExt();
        var result = (str?.Length ?? 0) <= maxLength;
        if (str is null || !result)
        {
            onNegativeAction?.Invoke();
            return false;
        }
        
        return result;
    }
    
    public static string? TrimExt(this string? str)
    {
        return str?.Trim();
    }
    
    public static bool IsNullOrEmptyExt(this string? str)
    {
        return string.IsNullOrEmpty(str);
    }
    
    public static bool IsNullOrWhiteSpaceExt(this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
    
    public static string? ToStringInvariantExt(this string? str)
    {
        return str?.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Replace keys to value in the current string
    /// </summary>
    /// <param name="str">source string with keys</param>
    /// <param name="replacements">dictionary with key-value</param>
    /// <returns>string</returns>
    public static string ReplaceExt(this string? str, Dictionary<string, string> replacements)
    {
        if (str.TrimExt().IsNullOrEmptyExt())
        {
            return string.Empty;
        }

        var result = new StringBuilder(str);
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
    /// Convert string to Base64 string
    /// </summary>
    /// <param name="str">source string value</param>
    /// <param name="encoding">encoding type, the method will use System.Text.Encoding.UTF8 as default</param>
    /// <returns>string</returns>
    public static string ToBase64Ext(this string str, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;
        return str.IsNullOrEmptyExt() ? str : Convert.ToBase64String(encoding.GetBytes(str));
    }
    
    /// <summary>
    /// Convert base64 string to string
    /// </summary>
    /// <param name="str">source string value</param>
    /// <param name="encoding">encoding type, the method will use System.Text.Encoding.UTF8 as default</param>
    /// <returns></returns>
    public static string FromBase64Ext(this string str, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;
        return str.IsNullOrEmptyExt() ? str : encoding.GetString(Convert.FromBase64String(str));
    }

    /// <summary>
    /// Join collection of strings to one string with
    /// </summary>
    /// <param name="value">source collection</param>
    /// <param name="separator"></param>
    /// <returns>string</returns>
    public static string JoinWithExt(this IEnumerable<string> value, string? separator)
    {
        return string.Join(separator, value);
    }
    
    /// <summary>
    /// Get only digits from string
    /// </summary>
    /// <param name="str">source string value</param>
    /// <returns>int?</returns>
    public static int? GetOnlyDigitsExt(this string str)
    {
        if (str.IsNullOrEmptyExt())
        {
            return null;
        }

        var digits = new string(str.Where(char.IsDigit).ToArray());
        return int.TryParse(digits, out var result) ? result : null;
    }
    
    /// <summary>
    /// Replace chars in source string
    /// </summary>
    /// <param name="str">source string</param>
    /// <param name="chars">chars to replace</param>
    /// <param name="replaceSymbol">replace to symbol</param>
    /// <returns>string</returns>
    public static string ReplaceCharsExt(this string? str, char[] chars, string replaceSymbol = "")
    {
        if (str.IsNullOrEmptyExt())
        {
            return str ?? string.Empty;
        }

        var result = new StringBuilder(str);
        foreach (var c in chars)
        {
            result.Replace(c.ToString(), replaceSymbol);
        }

        return result.ToString();
    }
    
    /// <summary>
    /// Replace chars in source string
    /// </summary>
    /// <param name="str">source string</param>
    /// <param name="chars">string of chars to replace</param>
    /// <param name="replaceSymbol">replace to symbol</param>
    /// <returns>string</returns>
    public static string ReplaceCharsExt(this string? str, string chars, string replaceSymbol = "")
    {
        return ReplaceCharsExt(str, chars.ToCharArray(), replaceSymbol);
    }
}