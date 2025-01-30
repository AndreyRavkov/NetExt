#if NET6_0_OR_GREATER
using System.Runtime.CompilerServices;
#endif

namespace NetExt.Utils.Common;

public static class CommonExtensions
{
    public static T GetValidatedValueExt<T>(
        this T? value,
        #if NETSTANDARD2_0 || NETSTANDARD2_1
        string? name = null
        #endif
        #if NET6_0_OR_GREATER
        [CallerArgumentExpression(nameof(value))]
        string? name = null
        #endif
    ) {
        return value ?? throw new ArgumentNullException($"Passed null value for required '{name}' param.");
    }
}