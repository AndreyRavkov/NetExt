using AR.NetExt.Strings;
using Xunit;

namespace AR.NetExt.UnitTests.Strings;

public class StringReplaceExtensionsTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ReplaceExt_NullOrEmpty_ReturnsEmpty(string? input)
    {
        var result = input.ReplaceExt(new Dictionary<string, string> { ["a"] = "b" });

        Assert.Equal(string.Empty, result);
    }

    [Theory]
    [InlineData("hello", "l", "L", "heLLo")]
    [InlineData("aaa", "a", "b", "bbb")]
    [InlineData("abcabc", "ab", "X", "XcXc")]
    [InlineData("a-b-c", "-", "", "abc")]
    [InlineData(" a ", "a", "b", " b ")]
    [InlineData("Hello", "hello", "x", "Hello")]
    [InlineData("Hello", "Hello", "x", "x")]
    [InlineData("Hello", "H", "h", "hello")]
    [InlineData("привет", "и", "i", "прiвет")]
    [InlineData("a", "a", "aa", "aa")]
    [InlineData("hello", "z", "Z", "hello")]
    [InlineData("   ", " ", "-", "---")]
    public void ReplaceExt_ReplacesKeyWithValue(string input, string key, string value, string expectedResult)
    {
        var result = input.ReplaceExt(new Dictionary<string, string> { [key] = value });

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ReplaceExt_EmptyDictionary_ReturnsOriginal()
    {
        const string input = "hello";

        var result = input.ReplaceExt(new Dictionary<string, string>());

        Assert.Equal(input, result);
    }

    [Fact]
    public void ReplaceExt_SkipsEmptyKeys()
    {
        var replacements = new Dictionary<string, string>
        {
            [""] = "X",
            ["l"] = "L",
        };

        var result = "hello".ReplaceExt(replacements);

        Assert.Equal("heLLo", result);
    }

    [Fact]
    public void ReplaceExt_AppliesNonOverlappingReplacements()
    {
        var replacements = new Dictionary<string, string>
        {
            ["{name}"] = "Ann",
            ["{city}"] = "Minsk",
        };

        var result = "{name} from {city}".ReplaceExt(replacements);

        Assert.Equal("Ann from Minsk", result);
    }

    [Fact]
    public void ReplaceExt_NullReplacements_ThrowsNullReferenceException()
    {
        Dictionary<string, string>? replacements = null;

        Assert.Throws<NullReferenceException>(() => "hello".ReplaceExt(replacements!));
    }

    [Theory]
    [InlineData(null, "a")]
    [InlineData("", "a")]
    public void ReplaceCharsExt_NullOrEmpty_ReturnsEmpty(string? input, string chars)
    {
        Assert.Equal(string.Empty, input.ReplaceCharsExt(chars));
        Assert.Equal(string.Empty, input.ReplaceCharsExt(chars.ToCharArray()));
    }

    [Theory]
    [InlineData("a1b2c3", "123", "", "abc")]
    [InlineData("hello", "aeiou", "", "hll")]
    [InlineData("a-b-c", "-", "_", "a_b_c")]
    [InlineData("a.b.c", ".", " -> ", "a -> b -> c")]
    [InlineData("Hello", "h", "x", "Hello")]
    [InlineData("hello", "h", "H", "Hello")]
    [InlineData("a b", " ", "", "ab")]
    [InlineData("a b", " ", "_", "a_b")]
    [InlineData("   ", " ", "", "")]
    [InlineData("   ", "x", "", "   ")]
    [InlineData("abc", "", "x", "abc")]
    [InlineData("aaa", "aa", "", "")]
    [InlineData("café", "é", "e", "cafe")]
    [InlineData("bookkeeper", "eo", "", "bkkpr")]
    [InlineData("a", "ax", "xy", "xyy")]
    [InlineData("a", "xa", "xy", "xy")]
    public void ReplaceCharsExt_String_ReplacesEachChar(
        string input,
        string chars,
        string replaceSymbol,
        string expectedResult)
    {
        var result = input.ReplaceCharsExt(chars, replaceSymbol);

        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ReplaceCharsExt_CharArray_ReplacesEachCharInOrder()
    {
        var result = "a-b-c".ReplaceCharsExt(['-', 'a'], "_");

        Assert.Equal("__b_c", result);
    }

    [Fact]
    public void ReplaceCharsExt_CharArray_DefaultRemovesChars()
    {
        var result = "a1b2c3".ReplaceCharsExt(['1', '2', '3']);

        Assert.Equal("abc", result);
    }

    [Fact]
    public void ReplaceCharsExt_CharArray_Empty_ReturnsOriginal()
    {
        const string input = "abc";

        var result = input.ReplaceCharsExt(Array.Empty<char>());

        Assert.Equal(input, result);
    }

    [Fact]
    public void ReplaceCharsExt_StringAndCharArray_Match()
    {
        const string input = "h e l l o";
        const string chars = "el ";

        var fromString = input.ReplaceCharsExt(chars, "-");
        var fromChars = input.ReplaceCharsExt(chars.ToCharArray(), "-");

        Assert.Equal("h-------o", fromString);
        Assert.Equal(fromString, fromChars);
    }

    [Fact]
    public void ReplaceCharsExt_NullCharArray_ThrowsNullReferenceException()
    {
        char[]? chars = null;

        Assert.Throws<NullReferenceException>(() => "abc".ReplaceCharsExt(chars!));
    }

    [Fact]
    public void ReplaceCharsExt_NullCharsString_ThrowsNullReferenceException()
    {
        string? chars = null;

        Assert.Throws<NullReferenceException>(() => "abc".ReplaceCharsExt(chars!));
    }
}