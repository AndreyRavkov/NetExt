using NetExt.Core.Models.Extensions;
using NetExt.Core.Strings;

namespace NetExt.Core.MayBe;

// ReSharper disable once StructLacksIEquatable.Global
public readonly struct MayBe<T> where T : class
{
    public static MayBe<T> Create(T? value) => new(value);
    
    public MayBe(T? value)
    {
        SourceValue = value;
    }
    
    private T? SourceValue { get; init; }

    public T Value => SourceValue ?? throw new ArgumentNullException(nameof(SourceValue));

    public bool Exists => SourceValue is not null;

    public override int GetHashCode()
    {
        return SourceValue == null ? 0 : Value.GetHashCode();
    }
    
    #region methods
    
    public T GetOrThrow(string? errorMessage = null, Type? exceptionType = null)
    {
        if (SourceValue is null)
        {
            if (exceptionType == typeof(ForbiddenException))
            {
                throw new ForbiddenException(GetText(errorMessage, "The value is forbidden"));
            }
            if (exceptionType == typeof(BadRequestException))
            {
                throw new BadRequestException(GetText(errorMessage, "The value not allowed"));
            }
            if (exceptionType == typeof(NotFoundException))
            {
                throw new NotFoundException(GetText(errorMessage, "The value not found"));
            }
            
            throw new ArgumentNullException(GetText(errorMessage, "The value is null"));
        }

        return SourceValue;
    }
    
    #endregion

    #region private methods

    private string GetText(string? errorMessage, string alternativeText)
    {
        return errorMessage ?? alternativeText;
    }

    #endregion
}