using NetExt.Core.Require;
using Xunit;

namespace NextExt.Core.UnitTests.Require;

public class RequireTests
{
    [Theory]
    [InlineData(null, null)]
    [InlineData("test_name", "")]
    [InlineData("test_name", "some error text")]
    public void ThrowIfNull_ThrowArgumentNullException_Test(string? objectName, string? errorMessage)
    {
        DateTime? tempDateTimeName = null;
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            if (objectName != null)
            {
                RequireExt.ThrowIfNull(tempDateTimeName, false, objectName, errorMessage);
            }
            else
            {
                RequireExt.ThrowIfNull(tempDateTimeName, errorMessage: errorMessage);
            }
        });
        Assert.IsType<ArgumentNullException>(exception);
        Assert.Equal(objectName ?? nameof(tempDateTimeName), exception.ParamName);
    }
    
    [Theory]
    [InlineData(null, null)]
    [InlineData("test_name", "")]
    [InlineData("test_name", "some error text")]
    public void ThrowIfNull_RequireException_Test(string? objectName, string? errorMessage)
    {
        DateTime? tempDateTimeName = null;
        var exception = Assert.Throws<RequireException>(() =>
        {
            if (objectName != null)
            {
                RequireExt.ThrowIfNull(tempDateTimeName, true, objectName:objectName, errorMessage);
            }
            else
            {
                RequireExt.ThrowIfNull(tempDateTimeName, true, errorMessage: errorMessage);
            }
        });
        Assert.IsType<RequireException>(exception);
        Assert.Equal(objectName ?? nameof(tempDateTimeName), ((ArgumentNullException)exception.InnerException!).ParamName);
        if (errorMessage != null)
        {
            Assert.Equal(errorMessage, exception.Message);
        }
    }
}
