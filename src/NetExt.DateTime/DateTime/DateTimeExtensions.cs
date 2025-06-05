namespace NetExt.DateTime;

public static class DateTimeExtensions
{
    /// <summary>
    /// Convert unix time milliseconds to DateTime in UTC
    /// </summary>
    /// <param name="unixTimeMilliseconds">source unix time milliseconds</param>
    /// <returns>DateTime</returns>
    public static System.DateTime ToUtcDateTimeExt(this long unixTimeMilliseconds)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(unixTimeMilliseconds).UtcDateTime;
    }

    /// <summary>
    /// Convert unix time seconds to DateTime in UTC
    /// </summary>
    /// <param name="unixTimeSeconds">source unit time seconds</param>
    /// <returns></returns>
    public static System.DateTime ToUtcDateTimeExt(this int unixTimeSeconds)
    {
        return DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds).UtcDateTime;
    }
    
    /// <summary>
    /// Convert DateTime to unit time milliseconds
    /// </summary>
    /// <param name="value">source DateTime</param>
    /// <returns></returns>
    public static long ToUnixTimeMillisecondsExt(this System.DateTime value)
    {
        return new DateTimeOffset(value).ToUnixTimeMilliseconds();
    }

    /// <summary>
    /// Specify kind for DateTime object
    /// </summary>
    /// <param name="value"></param>
    /// <param name="kind"></param>
    /// <returns></returns>
    public static System.DateTime ToSpecifyExt(this System.DateTime value, DateTimeKind kind = DateTimeKind.Utc)
    {
        return System.DateTime.SpecifyKind(value, kind);
    }
}