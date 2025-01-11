using System.Runtime.CompilerServices;

namespace NetExt.Core.Common;

public static class CommonExtensions
{
    public static T GetValidatedValueExt<T>(
        this T? value,
        #if NET6_0
        [CallerArgumentExpression("value")] string? name = null
        #endif
        #if NET7_0_OR_GREATER
        [CallerArgumentExpression(nameof(value))] string? name = null
        #endif
    )
    {
        return value ?? throw new ArgumentNullException($"Passed null value for required '{name}' param.");
    }
}