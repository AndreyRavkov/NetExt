using NetExt.Models.Exceptions;
using NetExt.Require.Extensions;
using Xunit;

namespace NextExt.UnitTests.Require;

public class RequireForbiddenExtensionsTests
{
    [Fact]
    public static void ThrowIfNullExtension_NotThrow_Tests()
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            dateTime.ThrowForbiddenIfNullExt();
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
        var result = Assert.Throws<ForbiddenExceptionExt>(() => dateTime.ThrowForbiddenIfNullExt());
        
        Assert.IsType<ForbiddenExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
}