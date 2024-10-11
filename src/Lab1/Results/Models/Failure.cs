using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public abstract record Failure : Result
{
    public sealed record ForceMoreThanAllowed : Failure { }

    public sealed record LimitOfSpeedError : Failure { }

    public sealed record RouteIsEmpty : Failure { }

    public sealed record StoppedOnHalfWay : Failure { }

    public sealed record TrainIsNull : Failure { }

    public override int ShowTimeOfRoute() { return 0; }
}