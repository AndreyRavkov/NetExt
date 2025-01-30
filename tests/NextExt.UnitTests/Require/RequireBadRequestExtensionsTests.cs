using NetExt.Models.Exceptions;
using NetExt.Require.Extensions;
using Xunit;

namespace NextExt.UnitTests.Require;

public class RequireBadRequestExtensionsTests
{
    [Fact]
    public static void ThrowIfNullExtension_NotThrow_Tests()
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            dateTime.ThrowBadRequestIfNullExt();
        }
        catch (Exception exception)
        {
            Assert.Fail($"Un expected exception to be thrown. {exception.Message}");
        }
    }
    
    [Fact]
    public static void ThrowIfNullExtension_Tests_1()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<BadRequestExceptionExt>(() => dateTime.ThrowBadRequestIfNullExt());
        
        Assert.IsType<BadRequestExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
}