namespace NetExt.Utils.Collections;

public static class CollectionsExtensions
{
    /// <summary>
    /// Convert element to list
    /// </summary>
    /// <param name="source">Source element to convert</param>
    /// <typeparam name="T">The type of the element in the list.</typeparam>
    /// <returns></returns>
    public static List<T> ToListExt<T>(this T? source)
    {
        return source is null ? [] : [source];
    }

    /// <summary>
    /// Convert IEnumerable to IReadOnlyList without duplication
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IReadOnlyList<T> AsReadOnlyListExt<T>(this IEnumerable<T>? source) =>
        source switch
        {
            null => [],
            IReadOnlyList<T> roList => roList,
            IList<T> list => list as IReadOnlyList<T>,
            _ => source.ToList(),
        }
        ?? [];
    
    /// <summary>
    /// Convert IEnumerable to List without duplication
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> AsListExt<T>(this IEnumerable<T>? source) =>
        source switch
        {
            null => [],
            List<T> list => list,
            _ => source.ToList(),
        };
}