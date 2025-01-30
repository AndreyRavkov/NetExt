using NetExt.Models.Enums;

namespace NetExt.MayBe.Extensions;

public static class MayBeExtensions
{
    public static MayBe<T> ToMayBe<T>(this T? obj) where T : class
    {
        return new MayBe<T>(obj);
    }
    
    public static T GetOrThrowForbidden<T>(this MayBe<T> source, string? errorMessage = null)
        where T : class
    {
        return source.GetOrThrow(errorMessage, ExceptionTypeExt.Forbidden);
    }
    
    public static T GetOrThrowBadRequest<T>(this MayBe<T> source, string? errorMessage = null)
        where T : class
    {
        return source.GetOrThrow(errorMessage, ExceptionTypeExt.BadRequest);
    }
    
    public static T GetOrThrowNotFound<T>(this MayBe<T> source, string? errorMessage = null)
        where T : class
    {
        return source.GetOrThrow(errorMessage, ExceptionTypeExt.NotFound);
    }

    #region async extensions
    
    public static async Task<MayBe<T>> ToMayBeAsync<T>(this Task<T> task) where T : class
    {
        return (await task.ConfigureAwait(false)).ToMayBe();
    }
    
    public static async Task<T> GetOrThrowAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null, ExceptionTypeExt? exceptionType = null)
        where T : class
    {
        return (await task.ConfigureAwait(false)).GetOrThrow(errorMessage, exceptionType);
    }
    
    public static Task<T> GetOrThrowForbiddenAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null)
        where T : class
    {
        return task.GetOrThrowAsync(errorMessage, ExceptionTypeExt.Forbidden);
    }
    
    public static Task<T> GetOrThrowBadRequestAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null)
        where T : class
    {
        return task.GetOrThrowAsync(errorMessage, ExceptionTypeExt.BadRequest);
    }
    
    public static Task<T> GetOrThrowNotFoundAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null)
        where T : class
    {
        return task.GetOrThrowAsync(errorMessage, ExceptionTypeExt.NotFound);
    }
    
    #endregion
}