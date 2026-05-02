using AR.NetExt.Models.Exceptions;
using AR.NetExt.Require.Extensions;
using Xunit;

namespace AR.NetExt.UnitTests.Require;

public class RequireBadRequestExtensionsTests
{
    [Fact]
    public static void ThrowIfNullExtension_NotThrow_Tests()
    {
        System.DateTime? dateTime = System.DateTime.MaxValue;
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
        System.DateTime? dateTime = null;
        var result = Assert.Throws<BadRequestExceptionExt>(() => dateTime.ThrowBadRequestIfNullExt());
        
        Assert.IsType<BadRequestExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
}