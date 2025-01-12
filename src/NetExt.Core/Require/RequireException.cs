namespace NetExt.Core.Require;

[Serializable]
public class RequireException: Exception
{
    public RequireException(string? message) : base(message)
    {
    }

    public RequireException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}