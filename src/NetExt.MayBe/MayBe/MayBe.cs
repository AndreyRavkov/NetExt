using NetExt.Models.Enums;
using NetExt.Models.Exceptions;

namespace NetExt.MayBe;

// ReSharper disable once StructLacksIEquatable.Global
public readonly struct MayBe<T> where T : class
{
    public static MayBe<T> Create(T? value) => new(value);
    
    public MayBe(T? value)
    {
        SourceValue = value;
    }
    
    #if NETSTANDARD2_0 || NETSTANDARD2_1
    private T? SourceValue { get; }
    #endif
    #if NET6_0_OR_GREATER
    private T? SourceValue { get; init; }
    #endif

    public T Value => SourceValue ?? throw new NullReferenceException(nameof(SourceValue));

    public bool Exists => SourceValue is not null;

    public override int GetHashCode()
    {
        return SourceValue == null ? 0 : Value.GetHashCode();
    }
    
    #region methods
    
    public T GetOrThrow(string? errorMessage = null, ExceptionTypeExt? exceptionType = ExceptionTypeExt.NullReference)
    {
        if (SourceValue is null)
        {
            switch (exceptionType)
            {
                case ExceptionTypeExt.BadRequest:
                    throw new BadRequestExceptionExt(GetText(errorMessage, "The value not allowed"));
                case ExceptionTypeExt.Forbidden:
                    throw new ForbiddenExceptionExt(GetText(errorMessage, "The value is forbidden"));
                case ExceptionTypeExt.Unauthorized:
                    throw new UnAuthorizationExceptionExt(GetText(errorMessage, "Unauthorized"));
                case ExceptionTypeExt.Require:
                    throw new RequireExceptionExt(GetText(errorMessage, "The value is required"));
                case ExceptionTypeExt.NotFound:
                    throw new NotFoundExceptionExt(GetText(errorMessage, "The value not found"));
                // ReSharper disable once RedundantCaseLabel
                case ExceptionTypeExt.ArgNull:
                // ReSharper disable once RedundantCaseLabel
                case ExceptionTypeExt.NullReference:
                default:
                    throw new NullReferenceException(GetText(errorMessage, "The value is null"));
            }
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