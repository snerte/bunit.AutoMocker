using System;
using System.Collections.Generic;
using System.Linq;

namespace Bunit.AutoMocker;

public class AutoMockerServiceProvider(Moq.AutoMock.AutoMocker mocker, params Type[] typesToExclude) : IServiceProvider
{
    private readonly HashSet<Type> _typesToExclude = typesToExclude.ToHashSet();
    private readonly Moq.AutoMock.AutoMocker _mocker = mocker;

    public object? GetService(Type serviceType)
    {
        // Never attempt to mock sealed classes
        if (serviceType.IsSealed)
            return null;

        return _typesToExclude.Contains(serviceType) 
            ? null 
            : _mocker.Get(serviceType);
    }
}