using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

public interface ITrain
{
    Result ApplyForce(int force);

    Result GoTroughRailway(int lenghtOfCurrentPath);

    Result PassengersMoving(int passengers);

    Result SlowDown(int limit);
}