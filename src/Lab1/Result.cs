namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Result
{
    protected string Message { get; init; } = string.Empty;

    protected int TimeOfRoute { get; init; }

    public string ShowMessage() { return Message; }

    public int ShowTimeOfRoute() { return TimeOfRoute; }
}