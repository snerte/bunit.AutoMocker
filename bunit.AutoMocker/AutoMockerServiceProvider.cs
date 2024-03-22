using System;

namespace Bunit.AutoMocker;

public class AutoMockerServiceProvider(Moq.AutoMock.AutoMocker mocker) : IServiceProvider
{
    private readonly Moq.AutoMock.AutoMocker _mocker = mocker;

    public object GetService(Type serviceType)
    {
        return _mocker.Get(serviceType);
    }
}