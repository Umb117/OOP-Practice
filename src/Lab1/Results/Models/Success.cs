using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public record Success : Result
{
    private int TimeOfRoute { get; init; }

    public override int ShowTimeOfRoute() { return TimeOfRoute; }

    public Success(int time)
    {
        TimeOfRoute = time;
    }
}