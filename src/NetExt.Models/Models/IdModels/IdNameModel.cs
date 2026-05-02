namespace NetExt.Models;

[Serializable]
public class IdNameModel<T, TY> : IdBaseModel<T, TY>
{
    public IdNameModel(T id, TY name) : base(id, name)
    {
        Id = id;
        Name = name;
    }

    public IdNameModel()
    {
    }

    public TY Name
    {
        get => Value;
        set => Value = value;
    }
}