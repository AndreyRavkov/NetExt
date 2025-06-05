using NetExt.Strings;
using Xunit;

namespace NextExt.UnitTests.Strings;

public class StringsTests
{
    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData(" abc", "abc")]
    [InlineData("  abc", "abc")]
    [InlineData("abc  ", "abc")]
    [InlineData("  \r abc  ", "abc")]
    [InlineData("  \n abc  ", "abc")]
    [InlineData("  abc  \r ", "abc")]
    [InlineData("  abc  \n ", "abc")]
    [InlineData(" \r abc  \n ", "abc")]
    [InlineData(" \n abc  \n ", "abc")]
    [InlineData(" \r abc  \r ", "abc")]
    [InlineData(" \r\n abc  \r\n ", "abc")]
    [InlineData(" \n\r abc  \n\r ", "abc")]
    public void TrimExt_Tests(string? input, string? expected)
    {
        var result = input.TrimExt();
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("\r\n", false)]
    [InlineData("\r\n", false, true)]
    [InlineData("abc", false)]
    [InlineData("abc", false, true)]
    [InlineData("", true)]
    [InlineData("", true, true)]
    [InlineData(" ", false)]
    [InlineData(" ", false, true)]
    [InlineData("   ", false)]
    [InlineData("   ", false, true)]
    [InlineData(null, true)]
    [InlineData(null, true, true)]
    public void IsNullOrVoidExt_Tests(string? input, bool expected, bool includeWhiteSpace = false)
    {
        var result = input.IsEmptyExt(includeWhiteSpace);
        
        Assert.Equal(expected, result);
    }
}