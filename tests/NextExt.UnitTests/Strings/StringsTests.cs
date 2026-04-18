using NetExt.Strings;
using Xunit;

namespace NextExt.UnitTests.Strings;

public class StringsTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("   ", false)]
    [InlineData("\r", false)]
    [InlineData("\n", false)]
    [InlineData("\r\n", false)]
    [InlineData("\n\r", false)]
    [InlineData(" abc", false)]
    [InlineData("  abc", false)]
    [InlineData("abc  ", false)]
    [InlineData("  \r abc  ", false)]
    [InlineData("  \n abc  ", false)]
    [InlineData("  abc  \r ", false)]
    [InlineData("  abc  \n ", false)]
    [InlineData(" \r abc  \n ", false)]
    [InlineData(" \n abc  \n ", false)]
    [InlineData(" \r abc  \r ", false)]
    [InlineData(" \r\n abc  \r\n ", false)]
    [InlineData(" \n\r abc  \n\r ", false)]
    public void IsNullOrEmptyExt_Tests(string? input, bool expectedResult)
    {
        var result = input.IsNullOrEmptyExt();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData(" ", true)]
    [InlineData("   ", true)]
    [InlineData("\r", true)]
    [InlineData("\n", true)]
    [InlineData("\r\n", true)]
    [InlineData("\n\r", true)]
    [InlineData("abc", false)]
    public void IsNullOrWhiteSpaceExt_Tests(string? input, bool expectedResult)
    {
        var result = input.IsNullOrWhiteSpaceExt();
        
        Assert.Equal(expectedResult, result);
    }
    
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("\r", true)]
    [InlineData("\n", true)]
    [InlineData("\r\n", true)]
    [InlineData("\n\r", true)]
    [InlineData(" abc", false)]
    [InlineData("  abc", false)]
    [InlineData("abc  ", false)]
    [InlineData("  \r abc  ", false)]
    [InlineData("  \n abc  ", false)]
    [InlineData("  abc  \r ", false)]
    [InlineData("  abc  \n ", false)]
    [InlineData(" \r abc  \n ", false)]
    [InlineData(" \n abc  \n ", false)]
    [InlineData(" \r abc  \r ", false)]
    [InlineData(" \r\n abc  \r\n ", false)]
    [InlineData(" \n\r abc  \n\r ", false)]
    public void IsNotNullOrEmptyOrWhiteSpaceExt_Tests(string? input, bool expectedResult)
    {
        var result = input.IsNotNullOrEmptyOrWhiteSpaceExt();
        
        Assert.Equal(expectedResult, result);
    }
}