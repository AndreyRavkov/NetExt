using NetExt.Models.Exceptions;
using NetExt.Require.Extensions;
using Xunit;

namespace NextExt.UnitTests.Require;

public class RequireNotFoundExtensionsTests
{
    [Fact]
    public static void ThrowIfNullExtension_NotThrow_Tests()
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            dateTime.ThrowNotFoundIfNullExt();
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
        var result = Assert.Throws<NotFoundExceptionExt>(() => dateTime.ThrowNotFoundIfNullExt());
        
        Assert.IsType<NotFoundExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
}