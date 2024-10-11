using Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths.Models;

public record NotPowerPath : PartOfRoute
{
    private int Length { get; init; }

    public NotPowerPath(int length) { Length = length; }

    public override Result TrainGoThroughPartOfRoute(ITrain train)
    {
        return train.GoTroughRailway(Length);
    }
}
