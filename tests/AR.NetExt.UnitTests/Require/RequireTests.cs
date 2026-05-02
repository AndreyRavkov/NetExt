using AR.NetExt.Models.Enums;
using AR.NetExt.Models.Exceptions;
using AR.NetExt.Require;
using Xunit;

namespace AR.NetExt.UnitTests.Require;

public class RequireTests
{
    [Fact]
    public static void ThrowIfNull_NotThrow_Tests()
    {
        System.DateTime? dateTime = System.DateTime.MaxValue;
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
        System.DateTime? dateTime = null;
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.ThrowIfNull(dateTime));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_Tests_2()
    {
        System.DateTime? dateTime = null;
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
        System.DateTime? dateTime = System.DateTime.MaxValue;
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
        System.DateTime? dateTime = null;
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.Require));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(nameof(dateTime), result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_ExceptionType_Tests_2()
    {
        System.DateTime? dateTime = null;
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.ArgNull));
        
        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal(nameof(dateTime), result.ParamName);
    }
    
    [Fact]
    public static void ThrowIfNull_ExceptionType_Tests_3()
    {
        System.DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.Require, objName));
        
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(objName, result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_ExceptionType_Tests_4()
    {
        System.DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.ThrowIfNull(dateTime, ExceptionTypeExt.ArgNull, objName));
        
        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal(objName, result.ParamName);
    }
    
    [Fact]
    public static void ThrowIfNull_That_NotThrow_Tests()
    {
        System.DateTime? dateTime = System.DateTime.MaxValue;
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
        System.DateTime? dateTime = null;
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.That(dateTime is not null));
        Assert.IsType<RequireExceptionExt>(result);
    }
    
    [Fact]
    public static void ThrowIfNull_That_Tests_2()
    {
        System.DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<RequireExceptionExt>(() => RequireExt.That(dateTime is not null, objName));
        Assert.IsType<RequireExceptionExt>(result);
        Assert.Equal(objName, result.Message);
    }
    
    [Fact]
    public static void ThrowIfNull_That_Tests_3()
    {
        System.DateTime? dateTime = null;
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.That(dateTime is not null, null, ExceptionTypeExt.ArgNull));
        Assert.IsType<ArgumentNullException>(result);
    }
    
    [Fact]
    public static void ThrowIfNull_That_Tests_4()
    {
        System.DateTime? dateTime = null;
        string objName = "some error message";
        var result = Assert.Throws<ArgumentNullException>(() => RequireExt.That(dateTime is not null, objName, ExceptionTypeExt.ArgNull));
        Assert.IsType<ArgumentNullException>(result);
        Assert.Equal(objName, result.ParamName);
    }
}
