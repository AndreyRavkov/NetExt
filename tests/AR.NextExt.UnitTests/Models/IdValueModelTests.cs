using NetExt.Models;
using Xunit;

namespace AR.NextExt.UnitTests.Models;

public class IdValueModelTests
{
    [Fact]
    public void Constructor_SetsIdAndName()
    {
        var model = new IdValueModel<int, string>(1, "test");

        Assert.Equal(1, model.Id);
        Assert.Equal("test", model.Value);
    }

    [Fact]
    public void DefaultConstructor_HasDefaultValues()
    {
        var model = new IdValueModel<int, string>();

        Assert.Equal(0, model.Id);
        Assert.Null(model.Value);
    }

    [Fact]
    public void Name_SetterUpdatesValue()
    {
        var model = new IdValueModel<int, string>(1, "original")
        {
            Value = "updated",
        };

        Assert.Equal("updated", model.Value);
    }

    [Fact]
    public void Equals_BothNull_ReturnsTrue()
    {
        var model = new IdValueModel<int, string>();

        Assert.True(model.Equals(null, null));
    }

    [Fact]
    public void Equals_FirstNull_ReturnsFalse()
    {
        var model = new IdValueModel<int, string>();
        var other = new IdValueModel<int, string>(1, "a");

        Assert.False(model.Equals(null, other));
    }

    [Fact]
    public void Equals_SecondNull_ReturnsFalse()
    {
        var model = new IdValueModel<int, string>();
        var other = new IdValueModel<int, string>(1, "a");

        Assert.False(model.Equals(other, null));
    }

    [Fact]
    public void Equals_SameId_ReturnsTrue()
    {
        var model = new IdValueModel<int, string>();
        var x = new IdValueModel<int, string>(1, "a");
        var y = new IdValueModel<int, string>(1, "b");

        Assert.True(model.Equals(x, y));
    }

    [Fact]
    public void Equals_DifferentId_ReturnsFalse()
    {
        var model = new IdValueModel<int, string>();
        var x = new IdValueModel<int, string>(1, "a");
        var y = new IdValueModel<int, string>(2, "a");

        Assert.False(model.Equals(x, y));
    }

    [Fact]
    public void Equals_BothNullId_ReturnsTrue()
    {
        var model = new IdValueModel<string, string>();
        var x = new IdValueModel<string, string>(null!, "a");
        var y = new IdValueModel<string, string>(null!, "b");

        Assert.True(model.Equals(x, y));
    }

    [Fact]
    public void GetHashCode_NullId_ReturnsZero()
    {
        var model = new IdValueModel<string, string>(null!, "a");
        var comparer = new IdValueModel<string, string>();

        Assert.Equal(0, comparer.GetHashCode(model));
    }

    [Fact]
    public void GetHashCode_NonNullId_ReturnsIdHashCode()
    {
        var model = new IdValueModel<int, string>(42, "a");
        var comparer = new IdValueModel<int, string>();

        Assert.Equal(42.GetHashCode(), comparer.GetHashCode(model));
    }
}
