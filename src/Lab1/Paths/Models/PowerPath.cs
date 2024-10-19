using Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths.Models;

public record PowerPath : PartOfRoute
{
    private int Lenght { get; init; }

    private int Force { get; init; }

    public PowerPath(int lenght, int force)
    {
        Lenght = lenght;
        Force = force;
    }

    public override Result TrainGoThroughPartOfRoute(ITrain train)
    {
        Result intermediateResult = train.ApplyForce(Force);
        return intermediateResult is not Result.Success ? intermediateResult : train.GoTroughRailway(Lenght);
    }
}
