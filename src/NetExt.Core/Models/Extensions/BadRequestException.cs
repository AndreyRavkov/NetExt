namespace NetExt.Core.Models.Extensions;

public class BadRequestException : Exception
{
    public BadRequestException(string? message)
        : base(message)
    {
    }

    public BadRequestException(string? message, Exception innerException)
        : base(message, innerException)
    {
    }
}