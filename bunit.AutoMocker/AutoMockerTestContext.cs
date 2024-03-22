namespace Bunit.AutoMocker;

public abstract class AutoMockerTestContext : TestContext
{
    protected readonly Moq.AutoMock.AutoMocker Mocker = new();

    public AutoMockerTestContext() : this(new Moq.AutoMock.AutoMocker(Moq.MockBehavior.Loose)) { }

    public AutoMockerTestContext(Moq.AutoMock.AutoMocker mocker)
    {
        Mocker = mocker;
        Services.AddFallbackServiceProvider(new AutoMockerServiceProvider(Mocker));
    }
}
