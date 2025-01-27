using System.Runtime.CompilerServices;
using NetExt.Core.Strings;

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
        object? value,
        bool useRequireException = false,
        [CallerArgumentExpression(nameof(value))] string? objectName = null,
        string? errorMessage = "")
    {
        if (value != null)
        {
            return;
        }
        if (useRequireException)
        {
            throw new RequireException(errorMessage, new ArgumentNullException(objectName));
        }
        throw new ArgumentNullException(objectName);
    }

    /// <summary>
    /// Require that string should be not null or empty or whitespace with trim option
    /// </summary>
    /// <param name="value"></param>
    /// <param name="checkWhiteSpace"></param>
    /// <param name="trim"></param>
    /// <param name="useRequireException"></param>
    /// <param name="objectName"></param>
    /// <param name="errorMessage"></param>
    /// <exception cref="RequireException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public static void ThrowIfNullOrVoid(
        string? value,
        bool checkWhiteSpace = false,
        bool trim = false,
        bool useRequireException = false,
        [CallerArgumentExpression(nameof(value))] string? objectName = null,
        string errorMessage = "")
    {
        if (!value.IsNullOrVoidExt(checkWhiteSpace, trim))
        {
            return;
        }
        if (useRequireException)
        {
            throw new RequireException(errorMessage, new ArgumentNullException(objectName));
        }
        throw new ArgumentNullException(objectName);
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