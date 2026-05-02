namespace NetExt.Models;

[Serializable]
public class IdNameModel<T, TY> : IEqualityComparer<IdNameModel<T, TY>>
{
    public IdNameModel(T id, TY name)
    {
        Id = id;
        Name = name;
    }

    public IdNameModel()
    {
    }
    
    public T Id { get; set; } = default!;
    public TY Name { get; set; } = default!;
    
    public virtual bool Equals(IdNameModel<T, TY>? x, IdNameModel<T, TY>? y)
    {
        if (x is null && y is null)
        {
            return true;
        }
        if (x is null || y is null)
        {
            return false;
        }
        if (x.Id is null && y.Id is null)
        {
            return true;
        }

        return x.Id!.Equals(y.Id);
    }

    public virtual int GetHashCode(IdNameModel<T, TY> obj)
    {
        return obj.Id?.GetHashCode() ?? 0;
    }
}