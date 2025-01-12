using NetExt.Core.Require;

namespace NetExt.Core.Actions;

public static class TryExt
{
    public static async Task<T?> ExecuteAsync<T>(Func<Task<T?>> action,
                                                Action<Exception>? catchAction = null,
                                                Func<Exception, Task>? catchActionAsync = null,
                                                Action? finallyAction = null,
                                                Func<Task>? finallyActionAsync = null)
    {
        RequireExt.ThrowIfNull(action);

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
    
    public static Task ExecuteAsync(Func<Task> action,
                                   Action<Exception>? catchAction = null,
                                   Func<Exception, Task>? catchActionAsync = null,
                                   Action? finallyAction = null,
                                   Func<Task>? finallyActionAsync = null)
    {
        return ExecuteAsync(
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
    
    public static T? Execute<T>(Func<T> action,
                               Action<Exception>? catchAction = null,
                               Action? finallyAction = null)
    {
        RequireExt.ThrowIfNull(action);
        
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
    
    public static void Execute(Action action,
                              Action<Exception>? catchAction = null,
                              Action? finallyAction = null)
    {
        Execute(
            () =>
            {
                action();
                return new object();
            },
            catchAction,
            finallyAction);
    }
}