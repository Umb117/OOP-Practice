using Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
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
        Result intremediateResult = train.ApplyForce(Force);
        return intremediateResult is Failure ? intremediateResult : train.GoTroughRailway(Lenght);
    }
}
