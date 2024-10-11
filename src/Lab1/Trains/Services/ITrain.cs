using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

public interface ITrain
{
    public Result ApplyForce(int force);

    public Result GoTroughRailway(int lenghtOfCurrentPath);

    public Result PassengersMoving(int passengers);

    public Result SlowDown(int limit);
}