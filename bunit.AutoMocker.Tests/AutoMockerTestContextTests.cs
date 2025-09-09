using bunit.BlazorTestApp.Components;

namespace bunit.AutoMocker.Tests;

public class AutoMockerTestContextTests : AutoMockerTestBase
{
    [Fact]
    public void CreatesUnregisteredDependencies()
    {
        // Arrange
        Mocker.Use<IMydependency>(x => x.GetSomeValue() == "Hello World");

        // Act
        var cut = RenderComponent<Routes>();

        // Assert
        Assert.Contains(cut.Markup, "Hello World");
    }
}
