using NetExt.Models.Enums;
using NetExt.Models.Exceptions;
#if NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

namespace NetExt.Require.Extensions;

public static class RequireForbiddenExtensions
{
    /// <summary>
    /// Require that object should be not null
    /// </summary>
    /// <param name="obj">source object</param>
    /// <param name="errorOrObjectName">if param not set, then for .NET 6+ it will contain nameof(value) variable</param>
    /// <exception cref="ForbiddenExceptionExt"></exception>
    public static void ThrowForbiddenIfNullExt<T>(
        this T? obj,
        #if NETSTANDARD2_0 || NETSTANDARD2_1
        string? errorOrObjectName = null
        #endif
        #if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(obj))]
        string? errorOrObjectName = null
        #endif
    ) {
        RequireExt.ThrowIfNull(obj, ExceptionTypeExt.Forbidden, errorOrObjectName);
    }
}