namespace NetExt.Models.Exceptions;

public class UnAuthorizationException : Exception
{
    public UnAuthorizationException(string? message)
        : base(message)
    {
    }

    public UnAuthorizationException(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}