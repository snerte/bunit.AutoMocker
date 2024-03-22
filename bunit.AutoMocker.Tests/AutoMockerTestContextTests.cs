using bunit.BlazorTestApp.Components;
using Bunit;
using Bunit.AutoMocker;

namespace bunit.AutoMocker.Tests;

public class AutoMockerTestContextTests : AutoMockerTestContext
{
    [Fact]
    public void CreatesUnregisteredDependencies()
    {
        Mocker.Use<IMydependency>(x => x.GetSomeValue() == "Hello World");

        RenderComponent<Routes>();
    }
}

public class WithoutAutoMockerTests : TestContext
{
    [Fact]
    public void Fails_WhenDependenciesAreUnregistered()
    {
        Assert.Throws<InvalidOperationException>(() => RenderComponent<Routes>());
    }
}