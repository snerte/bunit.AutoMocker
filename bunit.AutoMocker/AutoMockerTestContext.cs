namespace Bunit.AutoMocker;

public abstract class AutoMockerTestContext : TestContext
{
    internal readonly Moq.AutoMock.AutoMocker Mocker;

    public AutoMockerTestContext() : this(new Moq.AutoMock.AutoMocker()) { }

    public AutoMockerTestContext(Moq.AutoMock.AutoMocker mocker)
    {
        Mocker = mocker;
        Services.AddFallbackServiceProvider(new AutoMockerServiceProvider(Mocker));
    }
}
