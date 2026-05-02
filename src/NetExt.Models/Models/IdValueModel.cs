namespace NetExt.Models;

[Serializable]
public class IdValueModel<T, TY> : IEqualityComparer<IdValueModel<T, TY>>
{
    public IdValueModel(T id, TY value)
    {
        Id = id;
        Value = value;
    }

    public IdValueModel()
    {
    }
    
    public T Id { get; set; } = default!;
    public TY Value { get; set; } = default!;
    
    public virtual bool Equals(IdValueModel<T, TY>? x, IdValueModel<T, TY>? y)
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

    public virtual int GetHashCode(IdValueModel<T, TY> obj)
    {
        return obj.Id?.GetHashCode() ?? 0;
    }
}