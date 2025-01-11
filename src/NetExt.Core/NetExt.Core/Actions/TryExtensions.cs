namespace NetExt.Core.Actions;

public static class TryExtensions
{
    public static async Task<T?> TryExtAsync<T>(Func<Task<T?>> action,
                                                Action<Exception>? catchAction = null,
                                                Func<Exception, Task>? catchActionAsync = null,
                                                Action? finallyAction = null,
                                                Func<Task>? finallyActionAsync = null)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }

        var result = default(T);
        try
        {
            result = await action().ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            if (catchAction == null && catchActionAsync == null)
            {
                throw;
            }
            catchAction?.Invoke(exception);
            if (catchActionAsync != null)
            {
                await catchActionAsync(exception).ConfigureAwait(false);
            }
        }
        finally
        {
            finallyAction?.Invoke();
            if (finallyActionAsync != null)
            {
                await finallyActionAsync().ConfigureAwait(false);
            }
        }
        
        return result;
    }
    
    public static Task TryExtAsync(Func<Task> action,
                                   Action<Exception>? catchAction = null,
                                   Func<Exception, Task>? catchActionAsync = null,
                                   Action? finallyAction = null,
                                   Func<Task>? finallyActionAsync = null)
    {
        return TryExtAsync(
            async () =>
            {
                await action().ConfigureAwait(false);
                return new object();
            },
            catchAction,
            catchActionAsync,
            finallyAction,
            finallyActionAsync
        );
    }
    
    public static T? TryExt<T>(Func<T> action,
                               Action<Exception>? catchAction = null,
                               Action? finallyAction = null)
    {
        if (action == null)
        {
            throw new ArgumentNullException(nameof(action));
        }
        
        var result = default(T);
        try
        {
            result = action();
        }
        catch (Exception exception)
        {
            if (catchAction == null)
            {
                throw;
            }
            catchAction(exception);
        }
        finally
        {
            finallyAction?.Invoke();
        }

        return result;
    }
    
    public static void TryExt(Action action,
                              Action<Exception>? catchAction = null,
                              Action? finallyAction = null)
    {
        TryExt(
            () =>
            {
                action();
                return new object();
            },
            catchAction,
            finallyAction);
    }
}