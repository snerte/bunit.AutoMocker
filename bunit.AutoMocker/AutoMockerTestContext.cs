using System;

namespace Bunit.AutoMocker;

public abstract class AutoMockerTestContext : TestContext
{
    protected readonly Moq.AutoMock.AutoMocker Mocker = new();

    public AutoMockerTestContext(params Type[] typesToExclude) : this(new Moq.AutoMock.AutoMocker(), typesToExclude) { }

    public AutoMockerTestContext(Moq.AutoMock.AutoMocker mocker, params Type[] typesToExclude)
    {
        Mocker = mocker;
        Services.AddFallbackServiceProvider(new AutoMockerServiceProvider(Mocker, typesToExclude));
    }
}
