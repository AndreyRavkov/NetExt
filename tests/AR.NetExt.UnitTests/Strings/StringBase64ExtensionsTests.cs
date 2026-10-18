using System.Text;
using AR.NetExt.Strings;
using Xunit;

namespace AR.NetExt.UnitTests.Strings;

public class StringBase64ExtensionsTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\r")]
    [InlineData("\n")]
    [InlineData("\r\n")]
    public void ToBase64Ext_Blank_ReturnsOriginal(string? input)
    {
        var result = input!.ToBase64Ext();

        Assert.Equal(input, result);
    }

    [Theory]
    [InlineData("a", "YQ==")]
    [InlineData("ab", "YWI=")]
    [InlineData("abc", "YWJj")]
    [InlineData("hello", "aGVsbG8=")]
    [InlineData("a b", "YSBi")]
    [InlineData("Hello, World!", "SGVsbG8sIFdvcmxkIQ==")]
    public void ToBase64Ext_EncodesUtf8ByDefault(string input, string expectedResult)
    {
        var result = input.ToBase64Ext();

        Assert.Equal(expectedResult, result);
        Assert.Equal(input.ToBase64Ext(Encoding.UTF8), result);
        Assert.Equal(input.ToBase64Ext(), result);
    }

    [Fact]
    public void ToBase64Ext_UsesProvidedEncoding()
    {
        const string input = "é";

        Assert.Equal("w6k=", input.ToBase64Ext(Encoding.UTF8));
        Assert.Equal("6Q==", input.ToBase64Ext(Encoding.Latin1));
        Assert.Equal("6QA=", input.ToBase64Ext(Encoding.Unicode));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\r")]
    [InlineData("\n")]
    [InlineData("\r\n")]
    public void FromBase64Ext_Blank_ReturnsOriginal(string? input)
    {
        var result = input!.FromBase64Ext();

        Assert.Equal(input, result);
    }

    [Theory]
    [InlineData("YQ==", "a")]
    [InlineData("YWI=", "ab")]
    [InlineData("YWJj", "abc")]
    [InlineData("aGVsbG8=", "hello")]
    [InlineData("YSBi", "a b")]
    [InlineData("SGVsbG8sIFdvcmxkIQ==", "Hello, World!")]
    public void FromBase64Ext_DecodesUtf8ByDefault(string input, string expectedResult)
    {
        var result = input.FromBase64Ext();

        Assert.Equal(expectedResult, result);
        Assert.Equal(input.FromBase64Ext(Encoding.UTF8), result);
        Assert.Equal(input.FromBase64Ext(), result);
    }

    [Fact]
    public void FromBase64Ext_UsesProvidedEncoding()
    {
        Assert.Equal("é", "w6k=".FromBase64Ext(Encoding.UTF8));
        Assert.Equal("é", "6Q==".FromBase64Ext(Encoding.Latin1));
        Assert.Equal("é", "6QA=".FromBase64Ext(Encoding.Unicode));
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("a b")]
    [InlineData("Hello, World!")]
    [InlineData("é")]
    [InlineData("привет")]
    public void ToBase64Ext_FromBase64Ext_RoundTrip(string input)
    {
        var encoded = input.ToBase64Ext();
        var decoded = encoded.FromBase64Ext();

        Assert.Equal(input, decoded);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("@@@@")]
    [InlineData("aGVsbG8")]
    public void FromBase64Ext_Invalid_ThrowsFormatException(string input)
    {
        Assert.Throws<FormatException>(() => input.FromBase64Ext());
    }
}