using NetExt.Models.Enums;
using NetExt.Models.Exceptions;
using NetExt.Require.Extensions;
using Xunit;

namespace NextExt.UnitTests.Require;

public class RequireExtensionsTests
{
    [Fact]
    public static void ThrowIfNullExtension_NotThrow_Tests()
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            dateTime.ThrowIfNullExt();
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
        var result = Assert.Throws<RequireExceptionExt>(() => dateTime.ThrowIfNullExt());
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Theory]
    [InlineData(ExceptionTypeExt.Require)]
    [InlineData(ExceptionTypeExt.ArgNull)]
    [InlineData(ExceptionTypeExt.Forbidden)]
    [InlineData(ExceptionTypeExt.BadRequest)]
    [InlineData(ExceptionTypeExt.NotFound)]
    [InlineData(ExceptionTypeExt.Unauthorized)]
    public static void ThrowIfNullExtension_ExceptionType_NotThrow_Tests(ExceptionTypeExt exceptionType)
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            dateTime.ThrowIfNullExt(exceptionType);
        }
        catch (Exception exception)
        {
            Assert.Fail($"Un expected exception to be thrown. {exception.Message}");
        }
    }
    
    [Fact]
    public static void ThrowIfNullExtension_ExceptionType_Tests_1()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<RequireExceptionExt>(() => dateTime.ThrowIfNullExt(ExceptionTypeExt.Require));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNullExtension_ExceptionType_Tests_2()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<ArgumentNullException>(() => dateTime.ThrowIfNullExt(ExceptionTypeExt.ArgNull));
        
        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal(nameof(dateTime), result.ParamName);
    }
    
    [Fact]
    public static void ThrowIfNullExtension_ExceptionType_Tests_3()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<BadRequestExceptionExt>(() => dateTime.ThrowIfNullExt(ExceptionTypeExt.BadRequest));
        
        Assert.IsType<BadRequestExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNullExtension_ExceptionType_Tests_4()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<ForbiddenExceptionExt>(() => dateTime.ThrowIfNullExt(ExceptionTypeExt.Forbidden));
        
        Assert.IsType<ForbiddenExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNullExtension_ExceptionType_Tests_5()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<NotFoundExceptionExt>(() => dateTime.ThrowIfNullExt(ExceptionTypeExt.NotFound));
        
        Assert.IsType<NotFoundExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNullExtension_ExceptionType_Tests_6()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<UnAuthorizationExceptionExt>(() => dateTime.ThrowIfNullExt(ExceptionTypeExt.Unauthorized));
        
        Assert.IsType<UnAuthorizationExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
}