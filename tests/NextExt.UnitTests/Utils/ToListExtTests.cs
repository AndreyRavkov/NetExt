using NetExt.Utils.Collections;
using Xunit;

namespace NextExt.UnitTests.Utils;

public class ToListExtTests
{
    private class SampleClass
    {
        public int Id { get; init; }
    }
    
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(999)]
    [InlineData(-1 * int.MaxValue)]
    [InlineData(int.MaxValue)]
    [InlineData(int.MinValue)]
    [InlineData(null)]
    public void IntTypeToList_Test(int? source)
    {
        var result = source.ToListExt();

        Assert.NotNull(result);
        
        if(source is null)
        {
            Assert.Empty(result);
            Assert.IsType<List<int?>>(result);
        }
        else
        {
            Assert.IsType<List<int?>>(result, exactMatch: false);
            Assert.True(result.Count == 1);
            Assert.Equal(source, result[0]);
        }
    }
    
    [Theory]
    [InlineData(0 * long.MaxValue)]
    [InlineData(-1 * long.MaxValue)]
    [InlineData(long.MaxValue)]
    [InlineData(long.MinValue)]
    [InlineData(null)]
    public void LongTypeToList_Test(long? source)
    {
        var result = source.ToListExt();

        Assert.NotNull(result);
        if (source is null)
        {
            Assert.Empty(result);
            Assert.IsType<List<long?>>(result);
        }
        else
        {
            Assert.IsType<List<long?>>(result, exactMatch: false);
            Assert.True(result.Count == 1);
            Assert.Equal(source, result[0]);
        }
    }
    
    [Theory]
    [InlineData("test")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void StringTypeToList_Test(string? source)
    {
        var result = source.ToListExt();

        Assert.NotNull(result);
        if (source is null)
        {
            Assert.Empty(result);
            Assert.IsType<List<string?>>(result);
        }
        else
        {
            Assert.IsType<List<string?>>(result, exactMatch: false);
            Assert.True(result.Count == 1);
            Assert.Equal(source, result[0]);
        }
    }

    [Fact]
    public void ClassTypeToList_Test()
    {
        var source = new SampleClass { Id = 1 };
        var result = source.ToListExt();

        Assert.NotNull(result);
        Assert.IsType<List<SampleClass>>(result, exactMatch: false);
        Assert.True(result.Count == 1);
        Assert.Equal(source, result[0]);
        Assert.Equal(source.Id, result[0].Id);
    }

    [Fact]
    public void NullClassTypeToList_Test()
    {
        SampleClass? source = null;
        var result = source.ToListExt();

        Assert.NotNull(result);
        Assert.Empty(result);
        Assert.IsType<List<SampleClass>>(result);
    }
}