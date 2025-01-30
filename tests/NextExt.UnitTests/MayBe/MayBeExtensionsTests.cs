using NetExt.MayBe;
using NetExt.MayBe.Extensions;
using NetExt.Models.Exceptions;
using Xunit;

namespace NextExt.UnitTests.MayBe;

public class MayBeExtensionsTests
{
    [Fact]
    public void MayBe_Create_Test_1()
    {
        var result = new MayBeTest().ToMayBe();
        
        Assert.True(result.Exists);
        Assert.True(result.Value.GetType() == typeof(MayBeTest));
        Assert.Equal(int.MaxValue, result.Value.Max);
        Assert.True(result.GetHashCode() > 0);
    }
    
    [Fact]
    public async Task MayBe_Create_Async_Test_1()
    {
        var result = await Task.FromResult(new MayBeTest()).ToMayBeAsync();
        
        Assert.True(result.Exists);
        Assert.True(result.Value.GetType() == typeof(MayBeTest));
        Assert.Equal(int.MaxValue, result.Value.Max);
        Assert.True(result.GetHashCode() > 0);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_Forbidden_Test_1(string? errorMessage)
    {
        var result = new MayBe<MayBeTest>(null);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<ForbiddenExceptionExt>(() => result.GetOrThrowForbidden(errorMessage));
        Assert.Equal(errorMessage ?? "The value is forbidden", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public async Task MayBe_GetOrThrow_Forbidden_Async_Test_1(string? errorMessage)
    {
        var result = new MayBe<MayBeTest>(null);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = await Assert
                            .ThrowsAsync<ForbiddenExceptionExt>(() => Task.FromResult(result).GetOrThrowForbiddenAsync(errorMessage));
        Assert.Equal(errorMessage ?? "The value is forbidden", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_BadRequest_Test_1(string? errorMessage)
    {
        var result = new MayBe<MayBeTest>(null);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<BadRequestExceptionExt>(() => result.GetOrThrowBadRequest(errorMessage));
        Assert.Equal(errorMessage ?? "The value not allowed", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public async Task MayBe_GetOrThrow_BadRequest_Async_Test_1(string? errorMessage)
    {
        var result = new MayBe<MayBeTest>(null);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = await Assert.ThrowsAsync<BadRequestExceptionExt>(() => Task.FromResult(result).GetOrThrowBadRequestAsync(errorMessage));
        Assert.Equal(errorMessage ?? "The value not allowed", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public void MayBe_GetOrThrow_NotFound_Test_1(string? errorMessage)
    {
        var result = MayBe<MayBeTest>.Create(null);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = Assert.Throws<NotFoundExceptionExt>(() => result.GetOrThrowNotFound(errorMessage));
        Assert.Equal(errorMessage ?? "The value not found", exception.Message);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("some error")]
    public async Task MayBe_GetOrThrow_NotFound_Async_Test_1(string? errorMessage)
    {
        var result = MayBe<MayBeTest>.Create(null);
        
        Assert.False(result.Exists);
        Assert.Equal(typeof(MayBe<MayBeTest>), result.GetType());
        Assert.True(result.GetHashCode() == 0);
        Assert.Throws<NullReferenceException>(() => result.Value);
        var exception = await Assert.ThrowsAsync<NotFoundExceptionExt>(() => Task.FromResult(result).GetOrThrowNotFoundAsync(errorMessage));
        Assert.Equal(errorMessage ?? "The value not found", exception.Message);
    }
}