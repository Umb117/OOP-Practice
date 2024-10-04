namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
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
            return new Failure("Forse must be less then MaxForce");
        }

        _speedBoost = force / _weight;

        return new Success(0);
    }

    public void ResetSpeedBoost()
    {
        _speedBoost = 0;
    }

    public Result GoTroughPath(int lenghtOfCurrentPath)
    {
        int timeInRide = 0;

        while (lenghtOfCurrentPath > 0)
        {
            _speed += _speedBoost * _accuracy;
            if (_speed <= 0)
            {
                return new Failure("Train stopped on half way");
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
        if (limit < _speed)
        {
            return new Failure($"Speed of train more than speed limit");
        }

        return new Success(0);
    }
}