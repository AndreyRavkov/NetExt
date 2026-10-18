using System.Text;

namespace AR.NetExt.Strings;

public static class StringBase64Extensions
{
    extension(string stringValue)
    {
        /// <summary>
        /// Convert string to Base64 string
        /// </summary>
        /// <param name="encoding">encoding type, the method will use System.Text.Encoding.UTF8 as default</param>
        /// <returns>string</returns>
        public string ToBase64Ext(Encoding? encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return stringValue.IsBlankExt()
                       ? stringValue
                       : Convert.ToBase64String(encoding.GetBytes(stringValue));
        }

        /// <summary>
        /// Convert base64 string to string
        /// </summary>
        /// <param name="encoding">encoding type, the method will use System.Text.Encoding.UTF8 as default</param>
        /// <returns></returns>
        public string FromBase64Ext(Encoding? encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return stringValue.IsBlankExt()
                       ? stringValue
                       : encoding.GetString(Convert.FromBase64String(stringValue));
        }
    }
}