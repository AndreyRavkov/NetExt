namespace NetExt.Models.Exceptions;

[Serializable]
public class RequireExceptionExt: Exception
{
    public RequireExceptionExt(string? message) : base(message)
    {
    }

    public RequireExceptionExt(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}