using Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths.Models;

public record Station : PartOfRoute
{
    private int LimitOfSpeed { get; init; }

    private int AmountOfPassengers { get; init; }

    public Station(int limit, int passengers)
    {
        LimitOfSpeed = limit;
        AmountOfPassengers = passengers;
    }

    public override Result TrainGoThroughPartOfRoute(ITrain train)
    {
        Result intermediateResult = train.SlowDown(LimitOfSpeed);
        return intermediateResult is not Result.Success ? intermediateResult : train.PassengersMoving(AmountOfPassengers);
    }
}
