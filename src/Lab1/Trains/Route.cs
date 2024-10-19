using Itmo.ObjectOrientedProgramming.Lab1.Paths.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Paths.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Route
{
    private readonly int _speedLimit;
    private readonly Queue<PartOfRoute> _partsOfRoute = new();
    private Train? _train;

    public Route(int speedLimit)
    {
        _speedLimit = speedLimit;
    }

    public void CreateTrain(int weight, int force, int accuracy)
    {
        Train train = new(weight, force, accuracy);
        _train = train;
    }

    public void CreateAndAddNotPowerPath(int lenght)
    {
        NotPowerPath notPowerPath = new(lenght);

        _partsOfRoute.Enqueue(notPowerPath);
    }

    public void CreateAndAddPowerPath(int lenght, int force)
    {
        PowerPath powerPath = new(lenght, force);

        _partsOfRoute.Enqueue(powerPath);
    }

    public void CreateAndAddStation(int limit, int passengers)
    {
        Station station = new(limit, passengers);

        _partsOfRoute.Enqueue(station);
    }

    public Result StartTrainRide()
    {
        if (_train == null)
        {
            return new Result.TrainIsNull();
        }

        if (_partsOfRoute.Count == 0)
        {
            return new Result.RouteIsEmpty();
        }

        int timeOfRoute = 0;

        while (_partsOfRoute.Count > 0)
        {
            PartOfRoute part = _partsOfRoute.Dequeue();
            Result intermediateResult = part.TrainGoThroughPartOfRoute(_train);

            if (intermediateResult is not Result.Success)
            {
                return intermediateResult;
            }

            timeOfRoute += intermediateResult.ShowTimeOfRoute();
            _train.ResetSpeedBoost();
        }

        Result resultSlowDown = _train.SlowDown(_speedLimit);
        return resultSlowDown is Result.Success ? new Result.Success(timeOfRoute) : resultSlowDown;
    }
}
