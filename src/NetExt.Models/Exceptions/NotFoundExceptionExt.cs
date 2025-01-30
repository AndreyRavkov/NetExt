namespace NetExt.Models.Exceptions;

[Serializable]
public class NotFoundExceptionExt : Exception
{
    public NotFoundExceptionExt(string? message)
        : base(message)
    {
    }

    public NotFoundExceptionExt(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}