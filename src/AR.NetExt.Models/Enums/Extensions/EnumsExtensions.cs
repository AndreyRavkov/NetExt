namespace AR.NetExt.Models.Enums.Extensions;

public static class EnumsExtensions
{
    public static int ToIntExt<T>(this T value) where T : Enum
        => Convert.ToInt32(value);
    
    public static byte ToByteExt<T>(this T value) where T : Enum
        => Convert.ToByte(value);
}