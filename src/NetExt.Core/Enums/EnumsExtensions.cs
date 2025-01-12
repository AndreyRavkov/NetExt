namespace NetExt.Core.Enums;

public static class EnumsExtensions
{
    public static int ToIntExt<T>(this T value) where T : Enum
    {
        return Convert.ToInt32(value);
    }
}