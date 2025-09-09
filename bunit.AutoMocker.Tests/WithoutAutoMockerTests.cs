using bunit.BlazorTestApp.Components;
using Bunit;
using Microsoft.Extensions.DependencyInjection;

namespace bunit.AutoMocker.Tests;

public class WithoutAutoMockerTests : TestContext
{
    [Fact]
    public void Fails_WhenDependenciesAreUnregistered()
    {
        Assert.Throws<InvalidOperationException>(() => RenderComponent<Routes>());
    }

    [Fact]
    public void Fails_WhenAllOnlyUsedDependencyIsRegisterd()
    {
        // Arrange
        var myDependency = new Moq.Mock<IMydependency>();
        myDependency.Setup(x => x.GetSomeValue()).Returns("Hello World");

        Services.AddSingleton<IMydependency>(myDependency.Object);

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => RenderComponent<Routes>());
    }

    [Fact]
    public void Succeeds_WhenAllDependenciesAreRegistered()
    {
        // Arrange
        var myDependency = new Moq.Mock<IMydependency>();
        myDependency.Setup(x => x.GetSomeValue()).Returns("Hello World");

        Services.AddSingleton<IMydependency>(myDependency.Object);

        var myOtherDependency = new Moq.Mock<IMyOtherDependency>();
        Services.AddSingleton<IMyOtherDependency>(myOtherDependency.Object);

        // Act
        var cut = RenderComponent<Routes>();

        // Assert
        Assert.Contains(cut.Markup, "Hello World");
    }
}