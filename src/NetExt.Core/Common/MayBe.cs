using NetExt.Core.Models.Extensions;
using NetExt.Core.Require;

namespace NetExt.Core.Common;

public readonly struct MayBe<T> where T : class
{
    public MayBe(T? value)
    {
        SourceValue = value;
    }
    
    private T? SourceValue { get; init; }

    public T Value => SourceValue ?? throw new ArgumentNullException(nameof(SourceValue));

    public bool Exists => SourceValue is not null;

    public T AssumeExists(string errorMessage, bool isForbidden = false)
    {
        if (SourceValue is null)
        {
            if (isForbidden)
            {
                throw new ForbiddenException(errorMessage);
            }
            throw new NotFoundException(errorMessage);
        }

        return SourceValue;
    }

    public override int GetHashCode()
    {
        return SourceValue == null ? 0 : Value.GetHashCode();
    }
}

public static class MayBeExtension
{
    public static async Task<T> AssumeExistsAsync<T>(this Task<MayBe<T>> task, string errorMessage, bool isForbidden = false)
        where T : class
    {
        RequireExt.ThrowIfNull(task);
        
        return (await task).AssumeExists(errorMessage, isForbidden);
    }
}