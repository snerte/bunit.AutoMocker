using bunit.BlazorTestApp.Components;

namespace bunit.AutoMocker.Tests;

public sealed class ExcludeTypesTests : AutoMockerTestBase
{
    public ExcludeTypesTests() : base(typeof(IMyOtherDependency))
    { }

    [Fact]
    public void WhenUnregisteredDependencyIsNotHandledByAutoMocker_ThrowsInvalidOperationException()
    {
        // Arrange
        Mocker.Use<IMydependency>(x => x.GetSomeValue() == "Hello World");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => RenderComponent<Routes>());
    }
}
