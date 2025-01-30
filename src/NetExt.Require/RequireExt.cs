using System.ComponentModel;
using NetExt.Models.Enums;
using NetExt.Models.Exceptions;
#if NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

namespace NetExt.Require;

public static class RequireExt
{
    /// <summary>
    /// Require that object should be not null
    /// </summary>
    /// <param name="value">source object</param>
    /// <param name="errorOrObjectName">if param not set, then for .NET 6+ it will contain nameof(value) variable</param>
    public static void ThrowIfNull(
        object? value,
        #if NETSTANDARD2_0 || NETSTANDARD2_1
        string? errorOrObjectName = null
        #endif
        #if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(value))] string? errorOrObjectName = null
        #endif
    ) {
        That(value != null, errorOrObjectName);
    }
    
    /// <summary>
    /// Require that object should be not null
    /// </summary>
    /// <param name="value">source object</param>
    /// <param name="exceptionType">exception type</param>
    /// <param name="errorOrObjectName">if param not set, then for .NET 6+ it will contain nameof(value) variable</param>
    public static void ThrowIfNull(
        object? value,
        ExceptionTypeExt exceptionType,
        #if NETSTANDARD2_0 || NETSTANDARD2_1
        string? errorOrObjectName = null
        #endif
        #if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(value))]
        string? errorOrObjectName = null
        #endif
    ) {
        if (!Enum.IsDefined(typeof(ExceptionTypeExt), exceptionType))
        {
            throw new InvalidEnumArgumentException(nameof(exceptionType), (int)exceptionType, typeof(ExceptionTypeExt));
        }
    
        That(value != null, errorOrObjectName, exceptionType);
    }

    /// <summary>
    /// Require that condition is valid
    /// </summary>
    /// <param name="condition">bool condition</param>
    /// <param name="errorMessage">error message or object name</param>
    /// <param name="exceptionType">type of throw exception</param>
    /// <exception cref="RequireExceptionExt"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="BadRequestExceptionExt"></exception>
    /// <exception cref="ForbiddenExceptionExt"></exception>
    /// <exception cref="NotFoundExceptionExt"></exception>
    /// <exception cref="UnAuthorizationExceptionExt"></exception>
    public static void That(bool condition, 
                            string? errorMessage = null,
                            ExceptionTypeExt exceptionType = ExceptionTypeExt.Require)
    {
        if (condition)
        {
            return;
        }
        switch (exceptionType)
        {
            case ExceptionTypeExt.ArgNull:
            {
                throw new ArgumentNullException(errorMessage);
            }
            case ExceptionTypeExt.BadRequest:
            {
                throw new BadRequestExceptionExt(errorMessage);
            }
            case ExceptionTypeExt.Forbidden:
            {
                throw new ForbiddenExceptionExt(errorMessage);
            }
            case ExceptionTypeExt.NotFound:
            {
                throw new NotFoundExceptionExt(errorMessage);
            }
            case ExceptionTypeExt.Unauthorized:
            {
                throw new UnAuthorizationExceptionExt(errorMessage);
            }
            case ExceptionTypeExt.Require:
            default:
            {
                throw new RequireExceptionExt(errorMessage);
            }
        }
    }
}