using Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths.Models;

public record NotPowerPath : PartOfRoute
{
    private int Lenght { get; init; }

    public NotPowerPath(int lenght) { Lenght = lenght; }

    public override Result TrainGoThroughPartOfRoute(ITrain train)
    {
        return train.GoTroughRailway(Lenght);
    }
}
