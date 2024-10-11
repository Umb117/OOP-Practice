namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public abstract record Result
{
    private int TimeOfRoute { get; init; }

    protected Result()
    {
        TimeOfRoute = 0;
    }

    public int ShowTimeOfRoute() { return TimeOfRoute; }

    public sealed record Success : Result
    {
        public Success(int time)
        {
            TimeOfRoute = time;
        }
    }

    public sealed record ForceMoreThanAllowed : Result { }

    public sealed record LimitOfSpeedError : Result { }

    public sealed record RouteIsEmpty : Result { }

    public sealed record StoppedOnHalfWay : Result { }

    public sealed record TrainIsNull : Result { }
}