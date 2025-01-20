using NetExt.Core.Models.Extensions;
using NetExt.Core.Require;

namespace NetExt.Core.MayBe;

public static class MayBeExtension
{
    public static T GetOrThrowForbidden<T>(this MayBe<T> source, string? errorMessage = null)
        where T : class
    {
        return source.GetOrThrow(errorMessage, typeof(ForbiddenException));
    }
    
    public static T GetOrThrowBadRequest<T>(this MayBe<T> source, string? errorMessage = null)
        where T : class
    {
        return source.GetOrThrow(errorMessage, typeof(BadRequestException));
    }
    
    public static T GetOrThrowNotFound<T>(this MayBe<T> source, string? errorMessage = null)
        where T : class
    {
        return source.GetOrThrow(errorMessage, typeof(NotFoundException));
    }
    
    public static async Task<T> GetOrThrowAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null, Type? exceptionType = null)
        where T : class
    {
        RequireExt.ThrowIfNull(task);
        return (await task).GetOrThrow(errorMessage, exceptionType);
    }
    
    public static Task<T> GetOrThrowForbiddenAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null)
        where T : class
    {
        return task.GetOrThrowAsync(errorMessage, typeof(ForbiddenException));
    }
    
    public static Task<T> GetOrThrowBadRequestAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null)
        where T : class
    {
        return task.GetOrThrowAsync(errorMessage, typeof(BadRequestException));
    }
    
    public static Task<T> GetOrThrowNotFoundAsync<T>(this Task<MayBe<T>> task, string? errorMessage = null)
        where T : class
    {
        return task.GetOrThrowAsync(errorMessage, typeof(NotFoundException));
    }
    
    public static MayBe<T> ToMayBe<T>(this T? obj) where T : class
    {
        return new MayBe<T>(obj);
    }
}