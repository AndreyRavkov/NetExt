namespace NetExt.Models;

public abstract class IdBaseModel<T, TY> : IEqualityComparer<IdValueModel<T, TY>>
{
    protected IdBaseModel(T id, TY value)
    {
        Id = id;
        Value = value;
    }

    protected IdBaseModel()
    {
    }

    public T Id { get; set; } = default!;
    protected TY Value { get; set; } = default!;

    public bool Equals(IdValueModel<T, TY>? x, IdValueModel<T, TY>? y)
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

    public int GetHashCode(IdValueModel<T, TY> obj)
    {
        return obj.Id?.GetHashCode() ?? 0;
    }
}