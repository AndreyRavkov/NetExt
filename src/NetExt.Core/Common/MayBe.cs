using NetExt.Core.Models.Extensions;

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