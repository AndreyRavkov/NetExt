namespace NetExt.Models.Exceptions;

[Serializable]
public class ForbiddenExceptionExt : Exception
{
    public ForbiddenExceptionExt(string? message)
        : base(message)
    {
    }

    public ForbiddenExceptionExt(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}