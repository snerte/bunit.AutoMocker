namespace bunit.BlazorTestApp.Components;

public interface IMydependency
{
    string GetSomeValue();
}

public interface IMyOtherDependency : IMydependency
{
}