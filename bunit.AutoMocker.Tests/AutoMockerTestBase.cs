using Bunit.AutoMocker;
using Microsoft.AspNetCore.Components;

namespace bunit.AutoMocker.Tests;

public abstract class AutoMockerTestBase(params Type[] typesToExclude)
    : AutoMockerTestContext(typesToExclude.Union(new[] { typeof(IComponentActivator) }).ToArray())
{ }
