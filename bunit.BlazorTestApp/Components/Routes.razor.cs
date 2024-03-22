using Microsoft.AspNetCore.Components;

namespace bunit.BlazorTestApp.Components;
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