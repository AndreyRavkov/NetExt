using NetExt.Core.Strings;
using Xunit;

namespace NextExt.Core.UnitTests.Strings;

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
    [InlineData("abc", false)]
    [InlineData(" ", false)]
    [InlineData("   ", false)]
    [InlineData(null, true)]
    [InlineData("", true)]
    // use trim
    [InlineData("\r\n", true, true)]
    [InlineData("abc", false, true)]
    [InlineData(" ", true, true)]
    [InlineData("   ", true, true)]
    [InlineData(null, true, true)]
    [InlineData("", true, true)]
    // use whitespace without trim
    [InlineData("\r\n", false, false, true)]
    [InlineData("abc", false, false, true)]
    [InlineData(" ", false, false, true)]
    [InlineData("   ", false, false, true)]
    [InlineData(null, true, false, true)]
    [InlineData("", true, false, true)]
    // use whitespace with trim
    [InlineData("\r\n", true, true, true)]
    [InlineData("abc", false, true, true)]
    [InlineData(" ", true, true, true)]
    [InlineData("   ", true, true, true)]
    [InlineData(null, true, true, true)]
    [InlineData("", true, true, true)]
    public void IsNullOrVoidExt_Tests(string? input, bool expected, bool includeTrim = false, bool includeWhiteSpace = false)
    {
        var result = input.IsNullOrVoidExt(includeWhiteSpace, includeTrim);
        
        Assert.Equal(expected, result);
    }
}