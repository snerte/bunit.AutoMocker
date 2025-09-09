This project combines [bunit](https://bunit.dev/) and [Moq.AutoMock][0] making it super easy to create tests for Blazor Components. All dependencies are mocked automatically with AutoMocker so that you only have to setup the dependencies you use! Making test code super clean, easy to read and write.

## Sample

Given `Routes.razor.cs`
``` cs
public partial class Routes
{
    [Inject]
    IMydependency MyDependency { get; set; } = null!;

    [Inject]
    IMyOtherDependency MyOtherDependency { get; set; } = null!;

    protected override void OnInitialized()
    {
        MyDependency.GetSomeValue();
    }
}
```

## Problem

Without AutoMocker the test setup process is tedious and requires a lot of maintenance. 

```cs
public class WithoutAutoMockerTests : TestContext
{
    [Fact]
    public void MyTest()
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
```

Every dependency needs to be setup, not setting up `IMyOtherDepencency` will cause the test to fail:

```cs 
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
```

## Solution

With Automocker writing tests is simple. Change `TestContext` to `AutoMockerTestContext` and use the `Mocker` field from the baseclass to setup AutoMocker. For more info and AutoMocker recepies, check [their docs][0]

``` cs
public class AutoMockerTestContextTests : AutoMockerTestContext
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
```

When a certain type should not be handled by AutoMocker, a list of types can be provided via the constructor to exclude:
``` cs
public class ExcludeTypesTests : AutoMockerTestContext
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
```

[0]:https://github.com/moq/Moq.AutoMocker