namespace NetExt.Models;

[Serializable]
public class IdValueModel<T, TY> : IdBaseModel<T, TY>
{
    public IdValueModel(T id, TY value) : base(id, value)
    {
        Id = id;
        Value = value;
    }

    public IdValueModel()
    {
    }
    
    public new TY Value
    {
        get => base.Value;
        set => base.Value = value;
    }
}