using System;

namespace Bunit.AutoMocker;

public class AutoMockerServiceProvider(Moq.AutoMock.AutoMocker mocker) : IServiceProvider
{
    private readonly Moq.AutoMock.AutoMocker Mocker = mocker;

    public object GetService(Type serviceType)
    {
        return Mocker.Get(serviceType);
    }
}