using Itmo.ObjectOrientedProgramming.Lab1.Results.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Trains.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Trains;

public class Train : ITrain
{
    private readonly int _weight;
    private readonly int _maxAvailbleForce;
    private readonly int _accuracy;
    private int _speed;
    private int _speedBoost;

    public Train(int weight, int force, int accuracy)
    {
        _weight = weight;
        _speed = 0;
        _speedBoost = 0;
        _maxAvailbleForce = force;
        _accuracy = accuracy;
    }

    public Result ApplyForce(int force)
    {
        if (force > _maxAvailbleForce)
        {
            return new Failure.ForceMoreThanAllowed();
        }

        _speedBoost = force / _weight;
        return new Success(0);
    }

    public void ResetSpeedBoost()
    {
        _speedBoost = 0;
    }

    public Result GoTroughRailway(int lenghtOfCurrentPath)
    {
        int timeInRide = 0;

        while (lenghtOfCurrentPath > 0)
        {
            _speed += _speedBoost * _accuracy;
            if (_speed <= 0)
            {
                return new Failure.StoppedOnHalfWay();
            }

            int passedWay = _speed * _accuracy;
            lenghtOfCurrentPath -= passedWay;
            timeInRide += _accuracy;
        }

        return new Success(timeInRide);
    }

    public Result PassengersMoving(int passengers)
    {
        int timeInRide = 0;
        timeInRide += passengers;
        return new Success(timeInRide);
    }

    public Result SlowDown(int limit)
    {
        return limit < _speed ? new Failure.LimitOfSpeedError() : new Success(0);
    }
}