namespace NetExt.Core.Collections;

public static class CollectionsExtensions
{
    public static IList<T> ToListExt<T>(this T? source)
    {
        return source == null ? new List<T>() : new List<T> { source };
    }
    
    public static IEnumerable<T> ToEnumerableListExt<T>(this T? source)
    {
        return ToListExt(source);
    }
    
    public static IReadOnlyList<T> ToReadOnlyListExt<T>(this T? source)
    {
        return (IReadOnlyList<T>)ToListExt(source);
    }
    
    public static void ForEachExt<T>(this IEnumerable<T> list, Action<T> action)
    {
        foreach (var item in list)
        {
            action(item);
        }
    }
}