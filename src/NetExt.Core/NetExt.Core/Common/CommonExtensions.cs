using System.Runtime.CompilerServices;

namespace NetExt.Core.Common;

public static class CommonExtensions
{
    public static T GetValidatedValueExt<T>(
        this T? value,
        [CallerArgumentExpression(nameof(value))] string? name = null)
    {
        return value ?? throw new ArgumentNullException($"Passed null value for required '{name}' param.");
    }
}