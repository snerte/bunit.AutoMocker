using bunit.BlazorTestApp.Components;
using Bunit.AutoMocker;

namespace bunit.AutoMocker.Tests;

public sealed class SealedTypesTests : AutoMockerTestBase
{
    [Fact]
    public void WhenSealedDependencyIsNotHandledByAutoMocker_ThrowsInvalidOperationException()
    {
        // Arrange
        var sut = new AutoMockerServiceProvider(Mocker);

        // Act
        var result = sut.GetService(typeof(MySealedDependency));

        // Assert
        Assert.Null(result);
    }
}
