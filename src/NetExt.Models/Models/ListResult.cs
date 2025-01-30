namespace NetExt.Models;

[Serializable]
public class ListResult<T> where T : class
{
    public ListResult()
    {
    }

    public ListResult(IReadOnlyList<T> items, ulong total)
    {
        Items = items;
        Total = total;
    }
    
    public IReadOnlyList<T> Items { get; set; } = new List<T>();
    public ulong Total { get; set; }
}