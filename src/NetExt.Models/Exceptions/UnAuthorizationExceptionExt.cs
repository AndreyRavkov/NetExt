namespace NetExt.Models.Exceptions;

[Serializable]
public class UnAuthorizationExceptionExt : Exception
{
    public UnAuthorizationExceptionExt(string? message)
        : base(message)
    {
    }

    public UnAuthorizationExceptionExt(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}