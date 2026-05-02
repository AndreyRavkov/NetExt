using NetExt.Utils.Collections;
using Xunit;

namespace AR.NextExt.UnitTests.Utils;

public class AsReadOnlyListTests
{
    private class SampleClass
    {
        public int Id { get; init; }
    }
    
    [Fact]
    public void AsReadOnlyList_Null_Test()
    {
        IEnumerable<decimal>? source = null;

        var result = source.AsReadOnlyListExt();

        Assert.NotNull(result);
        Assert.IsType<IReadOnlyList<decimal>>(result, exactMatch: false);
        Assert.Empty(result);
    }
    
    [Fact]
    public void AsReadOnlyList_IEnumerable_Test()
    {
        IEnumerable<SampleClass> source = new List<SampleClass>()
        {
            new() { Id = -10 },
            new() { Id = 0 },
            new() { Id = 10 },
        };

        var result = source.AsReadOnlyListExt();

        Assert.NotNull(result);
        Assert.IsType<IReadOnlyList<SampleClass>>(result, exactMatch: false);
        Assert.Equal(source.Count(), result.Count);
        var index = 0;
        foreach (var item in source)
        {
            Assert.Equal(item.Id, result[index].Id);
            index++;
        }
    }
    
    [Fact]
    public void AsReadOnlyList_List_Test()
    {
        List<SampleClass> source =
        [
            new() { Id = -10 },
            new() { Id = 0 },
            new() { Id = 10 },
        ];

        var result = source.AsReadOnlyListExt();

        Assert.NotNull(result);
        Assert.IsType<IReadOnlyList<SampleClass>>(result, exactMatch: false);
        Assert.Equal(source.Count, result.Count);
        for (int i = 0; i < result.Count; i++)
        {
            Assert.Equal(source[i].Id, result[i].Id);
        }
    }
    
    [Fact]
    public void AsReadOnlyList_Array_Test()
    {
        int[] source = [-10, 0, 10];

        var result = source.AsReadOnlyListExt();

        Assert.NotNull(result);
        Assert.IsType<IReadOnlyList<int>>(result, exactMatch: false);
        Assert.Equal(source.Length, result.Count);
        for (int i = 0; i < result.Count; i++)
        {
            Assert.Equal(source[i], result[i]);
        }
    }
    
    [Fact]
    public void AsReadOnlyList_Collection_Test()
    {
        ICollection<string> source = new List<string> { "-10", "0", "10" };

        var result = source.AsReadOnlyListExt();

        Assert.NotNull(result);
        Assert.IsType<IReadOnlyList<string>>(result, exactMatch: false);
        Assert.Equal(source.Count, result.Count);

        var index = 0;
        foreach (var item in source)
        {
            Assert.Equal(item, result[index]);
            index++;
        }
    }
    
    [Fact]
    public void AsReadOnlyList_HashSet_Test()
    {
        HashSet<double> source = [1.1, 2.2, -1.1, 0.0];

        var result = source.AsReadOnlyListExt();

        Assert.NotNull(result);
        Assert.IsType<IReadOnlyList<double>>(result, exactMatch: false);
        Assert.Equal(source.Count, result.Count);

        var index = 0;
        foreach (var item in source)
        {
            Assert.Equal(item, result[index]);
            index++;
        }
    }
}