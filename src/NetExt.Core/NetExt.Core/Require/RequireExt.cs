using System.Runtime.CompilerServices;

namespace NetExt.Core.Require;

public static class RequireExt
{
    /// <summary>
    /// Require that object should be not null
    /// </summary>
    /// <param name="value">source object</param>
    /// <param name="useRequireException">throw RequireException or ArgumentNullException in other cases</param>
    /// <param name="objectName">object name</param>
    /// <param name="errorMessage">error message</param>
    /// <exception cref="RequireException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static void ThrowIfNull(
        object value,
        bool useRequireException = false,
        #if NET6_0
        [CallerArgumentExpression("value")] string? objectName = null,
        #endif
        #if NET7_0_OR_GREATER
        [CallerArgumentExpression(nameof(value))] string? objectName = null,
        #endif
        string errorMessage = "")
    {
        if (value == null)
        {
            if (useRequireException)
            {
                throw new RequireException(errorMessage, new ArgumentNullException(objectName));
            }

            throw new ArgumentNullException(objectName);
        }
    }
    
    /// <summary>
    /// Require that condition is valid
    /// </summary>
    /// <param name="condition">bool condition</param>
    /// <param name="errorMessage">error message</param>
    /// <exception cref="RequireException"></exception>
    public static void That(bool condition, string? errorMessage)
    {
        if (!condition)
        {
            throw new RequireException(errorMessage);
        }
    }
}