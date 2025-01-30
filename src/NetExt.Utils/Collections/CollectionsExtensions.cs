namespace NetExt.Utils.Collections;

public static class CollectionsExtensions
{
    public static IList<T> ToListExt<T>(this T? source)
    {
        return source is null ? Array.Empty<T>() : new List<T> { source };
    }
    
    public static void ForEachExt<T>(this IEnumerable<T> list, Action<T> action)
    {
        foreach (var item in list)
        {
            action(item);
        }
    }
}