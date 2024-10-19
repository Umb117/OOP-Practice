using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;

public abstract record PartOfRoute
{
    public abstract Result TrainGoThroughPartOfRoute(ITrain train);
}
