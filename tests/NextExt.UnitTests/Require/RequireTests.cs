using NetExt.Models.Enums;
using NetExt.Models.Exceptions;
using NetExt.Require;
using Xunit;

namespace NextExt.UnitTests.Require;

public class RequireTests
{
    [Fact]
    public static void ThrowIfNull_NotThrow_Tests()
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            RequireExt.ThrowIfNull(dateTime);
        }
        catch (Exception exception)
        {
            Assert.Fail($"Un expected exception to be thrown. {exception.Message}");
        }
    }
    
    [Fact]
    public static void ThrowIfNull_Tests_1()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.ThrowIfNull(dateTime));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_Tests_2()
    {
        DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.ThrowIfNull(dateTime, objName));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(objName, result.Message);
    }
    
    [Theory]
    [InlineData(ExceptionTypeExt.Require)]
    [InlineData(ExceptionTypeExt.ArgNull)]
    public static void ThrowIfNull_ExceptionType_Tests(ExceptionTypeExt exceptionType)
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            RequireExt.ThrowIfNull(dateTime, exceptionType);
        }
        catch (Exception exception)
        {
            Assert.Fail($"Un expected exception to be thrown. {exception.Message}");
        }
    }
    
    [Fact]
    public static void ThrowIfNull_ExceptionType_Tests_1()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.Require));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_ExceptionType_Tests_2()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.ArgNull));
        
        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal(nameof(dateTime), result.ParamName);
    }
    
    [Fact]
    public static void ThrowIfNull_ExceptionType_Tests_3()
    {
        DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.Require, objName));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(objName, result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_ExceptionType_Tests_4()
    {
        DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.ArgNull, objName));
        
        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal(objName, result.ParamName);
    }
    
    [Fact]
    public static void ThrowIfNull_That_NotThrow_Tests()
    {
        DateTime? dateTime = DateTime.MaxValue;
        try
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            RequireExt.That(dateTime is not null);
        }
        catch (Exception exception)
        {
            Assert.Fail($"Un expected exception to be thrown. {exception.Message}");
        }
    }
    
    [Fact]
    public static void ThrowIfNull_That_Tests_1()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.That(dateTime is not null));
        Assert.IsType<RequireExceptionExt>(result);
    }
    
    [Fact]
    public static void ThrowIfNull_That_Tests_2()
    {
        DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.That(dateTime is not null, objName));
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(objName, result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_That_Tests_3()
    {
        DateTime? dateTime = null;
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.That(dateTime is not null, null, ExceptionTypeExt.ArgNull));
        Assert.IsType<ArgumentNullException>(result);
    }
    
    [Fact]
    public static void ThrowIfNull_That_Tests_4()
    {
        DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.That(dateTime is not null, objName, ExceptionTypeExt.ArgNull));
        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal(objName, result.ParamName);
    }
}
