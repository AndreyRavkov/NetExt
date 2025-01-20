using NetExt.Core.MayBe;
using NetExt.Core.Models.Extensions;
using Xunit;

namespace NextExt.Core.UnitTests.MayBe;

public class MayBeTests
{
    [Fact]
    public void MayBe_Create_Test_1()
    {
        var result = new MayBe<MayBeTest>(new MayBeTest());
        
        Assert.True(result.Exists);
        Assert.True(result.Value.GetType() == typeof(MayBeTest));
        Assert.True(result.GetHashCode() > 0);
    }
    
    [Fact]
    public void MayBe_Create_Test_2()
    {
        var result = MayBe<MayBeTest>.Create(new MayBeTest());
        
        Assert.True(result.Exists);
        Assert.True(result.Value.GetType() == typeof(MayBeTest));
        Assert.True(result.GetHashCode() > 0);
    }
    
    [Fact]
    public void MayBe_Create_Test_3()
    {
        var result = new MayBe<MayBeTest>(null);
        
        Assert.False(result.Exists);
        Assert.Throws<ArgumentNullException>(() => result.Value);
        Assert.Equal(0, result.GetHashCode());
    }
    
    [Fact]
    public void MayBe_Create_Test_4()
    {
        var result = MayBe<MayBeTest>.Create(null);
        
        Assert.False(result.Exists);
        Assert.Throws<ArgumentNullException>(() => result.Value);
        Assert.Equal(0, result.GetHashCode());
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Success()
    {
        var result = MayBe<MayBeTest>.Create(new MayBeTest()).GetOrThrow();
        
        Assert.NotNull(result);
        Assert.IsType<MayBeTest>(result);
        Assert.Equal(int.MaxValue, result.Max);
    }
    
    [Fact]
    public void ToMayBe_Test()
    {
        var result = (new MayBeTest()).ToMayBe();
        
        Assert.IsType<MayBe<MayBeTest>>(result);
        Assert.True(result.Exists);
        Assert.True(result.GetHashCode() > 0);
    }
    
    [Fact]
    public void ToMayBe_Nullable_Test()
    {
        MayBeTest? source = null;
        var result = source.ToMayBe();
        
        Assert.IsType<MayBe<MayBeTest>>(result);
        Assert.False(result.Exists);
        Assert.Equal(0, result.GetHashCode());
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_ArgumentNullException_1()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => MayBe<MayBeTest>.Create(null).GetOrThrow());
        
        Assert.Equal("The value is null", exception.ParamName);
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_ArgumentNullException_2()
    {
        var message = "unit test error message";
        var exception = Assert.Throws<ArgumentNullException>(() => MayBe<MayBeTest>.Create(null).GetOrThrow(errorMessage: message));
        
        Assert.Equal(message, exception.ParamName);
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_ForbiddenException_1()
    {
        var exception = Assert.Throws<ForbiddenException>(() => MayBe<MayBeTest>.Create(null).GetOrThrowForbidden());
        
        Assert.Equal("The value is forbidden", exception.Message);
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_ForbiddenException_2()
    {
        var message = "unit test error message";
        var exception = Assert.Throws<ForbiddenException>(() => MayBe<MayBeTest>.Create(null).GetOrThrowForbidden(errorMessage: message));
        
        Assert.Equal(message, exception.Message);
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_BadRequestException_1()
    {
        var exception = Assert.Throws<BadRequestException>(() => MayBe<MayBeTest>.Create(null).GetOrThrowBadRequest());
        
        Assert.Equal("The value not allowed", exception.Message);
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_BadRequestException_2()
    {
        var message = "unit test error message";
        var exception = Assert.Throws<BadRequestException>(() => MayBe<MayBeTest>.Create(null).GetOrThrowBadRequest(errorMessage: message));
        
        Assert.Equal(message, exception.Message);
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_NotFoundException_1()
    {
        var exception = Assert.Throws<NotFoundException>(() => MayBe<MayBeTest>.Create(null).GetOrThrowNotFound());
        
        Assert.Equal("The value not found", exception.Message);
    }
    
    [Fact]
    public void MayBe_GetOrThrow_Test_Throw_NotFoundException_2()
    {
        var message = "unit test error message";
        var exception = Assert.Throws<NotFoundException>(() => MayBe<MayBeTest>.Create(null).GetOrThrowNotFound(errorMessage: message));
        
        Assert.Equal(message, exception.Message);
    }
}

internal class MayBeTest
{
    public int Max => int.MaxValue;
}