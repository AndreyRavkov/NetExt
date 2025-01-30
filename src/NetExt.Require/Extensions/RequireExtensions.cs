
using NetExt.Models.Enums;
#if NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

namespace NetExt.Require.Extensions;

public static class RequireExtensions
{
    /// <summary>
    /// Require that object should be not null
    /// </summary>
    /// <param name="obj">source object</param>
    /// <param name="errorOrObjectName">if param not set, then for .NET 6+ it will contain nameof(value) variable</param>
    public static void ThrowIfNullExt<T>(
        this T? obj,
        #if NETSTANDARD2_0 || NETSTANDARD2_1
        string? errorOrObjectName = null
        #endif
        #if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(obj))]
        string? errorOrObjectName = null
        #endif
    ) {
        RequireExt.ThrowIfNull(obj, errorOrObjectName);
    }

    /// <summary>
    /// Require that object should be not null
    /// </summary>
    /// <param name="obj">source object</param>
    /// <param name="exceptionType">exception type</param>
    /// <param name="errorOrObjectName">if param not set, then for .NET 6+ it will contain nameof(value) variable</param>
    public static void ThrowIfNullExt<T>(
        this T? obj,
        ExceptionTypeExt exceptionType,
        #if NETSTANDARD2_0 || NETSTANDARD2_1
        string? errorOrObjectName = null
        #endif
        #if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(obj))]
        string? errorOrObjectName = null
        #endif
    ) {
        RequireExt.ThrowIfNull(obj, exceptionType, errorOrObjectName);
    }
}