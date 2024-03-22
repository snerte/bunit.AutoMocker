namespace Bunit.AutoMocker;

public abstract class AutoMockerTestContext : TestContext
{
    internal readonly Moq.AutoMock.AutoMocker _mocker = new();

    public AutoMockerTestContext()
    {
        Services.AddFallbackServiceProvider(new AutoMockerServiceProvider(_mocker));
    }
}
