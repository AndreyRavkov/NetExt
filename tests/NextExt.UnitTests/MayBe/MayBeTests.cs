using NetExt.MayBe;
using NetExt.Models.Enums;
using NetExt.Models.Exceptions;
using Xunit;

namespace NextExt.UnitTests.MayBe;

public class MayBeTests
{
    [Fact]
    public void MayBe_Create_Test_1()
    {
        var result = CreateMayBe(isNullable:false);
        
        Assert.True(result.Exists);
        Assert.True(result.Value.GetType() == typeof(MayBeTest));
        Assert.Equal(int.MaxValue, result.Value.Max);
        Assert.True(result.GetHashCode() > 0);
    }
    
    [Fact]
    public void MayBe_Create_Test_2()
    {
        var result = CreateMayBe(isNullable:true);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
    }
    
    [Theory]
    [InlineData(null, null)]
    [InlineData("some error", null)]
    [InlineData(null, ExceptionTypeExt.ArgNull)]
    [InlineData("some error", ExceptionTypeExt.ArgNull)]
    [InlineData(null, ExceptionTypeExt.NullReference)]
    [InlineData("some error", ExceptionTypeExt.NullReference)]
    [InlineData(null, (ExceptionTypeExt)9999)]
    [InlineData("some error", (ExceptionTypeExt)9999)]
    public void MayBe_GetOrThrow_Test_1(string? errorMessage, ExceptionTypeExt? exceptionType)
    {
        var result = CreateMayBe(isNullable:true);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<NullReferenceException>(() => result.GetOrThrow(errorMessage, exceptionType));
        Assert.Equal(errorMessage ?? "The value is null", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_Test_2(string? errorMessage)
    {
        var result = CreateMayBe(isNullable:true);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<BadRequestExceptionExt>(() => result.GetOrThrow(errorMessage, ExceptionTypeExt.BadRequest));
        Assert.Equal(errorMessage ?? "The value not allowed", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_Test_3(string? errorMessage)
    {
        var result = CreateMayBe(isNullable:true);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<ForbiddenExceptionExt>(() => result.GetOrThrow(errorMessage, ExceptionTypeExt.Forbidden));
        Assert.Equal(errorMessage ?? "The value is forbidden", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_Test_4(string? errorMessage)
    {
        var result = CreateMayBe(isNullable:true);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<UnAuthorizationExceptionExt>(() => result.GetOrThrow(errorMessage, ExceptionTypeExt.Unauthorized));
        Assert.Equal(errorMessage ?? "Unauthorized", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_Test_5(string? errorMessage)
    {
        var result = CreateMayBe(isNullable:true);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<RequireExceptionExt>(() => result.GetOrThrow(errorMessage, ExceptionTypeExt.Require));
        Assert.Equal(errorMessage ?? "The value is required", exception.Message);
    }
    
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_Test_6(string? errorMessage)
    {
        var result = CreateMayBe(isNullable:true);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<NotFoundExceptionExt>(() => result.GetOrThrow(errorMessage, ExceptionTypeExt.NotFound));
        Assert.Equal(errorMessage ?? "The value not found", exception.Message);
    }
    
    private MayBe<MayBeTest> CreateMayBe(bool isNullable = false)
    {
        return isNullable ? new MayBe<MayBeTest>(null) : MayBe<MayBeTest>.Create(new MayBeTest());
    }
}