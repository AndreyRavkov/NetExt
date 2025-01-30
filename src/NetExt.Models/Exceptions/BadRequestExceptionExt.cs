namespace NetExt.Models.Exceptions;

[Serializable]
public class BadRequestExceptionExt : Exception
{
    public BadRequestExceptionExt(string? message)
        : base(message)
    {
    }

    public BadRequestExceptionExt(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}