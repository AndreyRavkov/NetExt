using System.Globalization;

namespace AR.NetExt.Strings;

public static class StringsExtensions
{
    extension(string? stringValue)
    {
        public bool IsNullOrEmptyExt()
        {
            return string.IsNullOrEmpty(stringValue);
        }

        /// <summary>
        /// A shorter alias for <see cref="IsNullOrEmptyExt" />
        /// </summary>
        /// <returns></returns>
        public bool IsEmptyExt()
        {
            return string.IsNullOrEmpty(stringValue);
        }

        public bool IsNullOrWhiteSpaceExt()
        {
            return string.IsNullOrWhiteSpace(stringValue);
        }

        /// <summary>
        /// A shorter alias for <see cref="IsNullOrWhiteSpaceExt" />
        /// </summary>
        /// <returns>bool result</returns>
        public bool IsBlankExt()
        {
            return string.IsNullOrWhiteSpace(stringValue);
        }

        public bool HasMaxLengthExt(
            int maxLength,
            Action? onNegativeAction = null)
        {
            stringValue = stringValue?.Trim();
            var result = (stringValue?.Length ?? 0) <= maxLength;
            if (stringValue is null || !result)
            {
                onNegativeAction?.Invoke();
                return false;
            }

            return result;
        }
    }

    /// <summary>
    /// Convert object to string with CultureInfo.InvariantCulture as IFormatProvider
    /// </summary>
    /// <param name="stringValue"></param>
    /// <param name="provider"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string? ToStringExt<T>(this T? stringValue, IFormatProvider? provider = null)
    {
        provider ??= CultureInfo.InvariantCulture;
        if (stringValue is null)
        {
            return null;
        }

        return stringValue switch
        {
            string strValue => strValue.ToString(provider),
            int intValue => intValue.ToString(provider),
            uint uintValue => uintValue.ToString(provider),
            long longValue => longValue.ToString(provider),
            ulong ulongValue => ulongValue.ToString(provider),
            float floatValue => floatValue.ToString(provider),
            double doubleValue => doubleValue.ToString(provider),
            decimal decimalValue => decimalValue.ToString(provider),
            bool boolValue => boolValue.ToString(provider),
            byte byteValue => byteValue.ToString(provider),
            sbyte sbyteValue => sbyteValue.ToString(provider),
            short shortValue => shortValue.ToString(provider),
            ushort ushortValue => ushortValue.ToString(provider),
            DateTime dateTime => dateTime.ToString(provider),
            DateTimeOffset dateTimeOffset => dateTimeOffset.ToString(provider),
            #if NET6_0_OR_GREATER
            nint nintValue => nintValue.ToString(provider),
            DateOnly dateOnly => dateOnly.ToString(provider),
            #endif
            _ => stringValue.ToString(),
        };
    }

    /// <summary>
    /// Join a collection of strings to one string with
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
    /// <param name="stringValue">source string value</param>
    /// <returns>int?</returns>
    public static int? GetOnlyDigitsExt(this string stringValue)
    {
        if (stringValue.IsNullOrEmptyExt())
        {
            return null;
        }

        var digits = new string(stringValue.Where(char.IsDigit).ToArray());
        return int.TryParse(digits, out var result) ? result : null;
    }
}