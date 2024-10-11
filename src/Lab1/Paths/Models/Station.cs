using Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths.Models;

public record Station : PartOfRoute
{
    private int LimitOfSpeed { get; init; }

    private int AmountOfPassangers { get; init; }

    public Station(int limit, int passengers)
    {
        LimitOfSpeed = limit;
        AmountOfPassangers = passengers;
    }

    public override Result TrainGoThroughPartOfRoute(ITrain train)
    {
        Result intremediateResult = train.SlowDown(LimitOfSpeed);
        return intremediateResult is Failure ? intremediateResult : train.PassengersMoving(AmountOfPassangers);
    }
}
