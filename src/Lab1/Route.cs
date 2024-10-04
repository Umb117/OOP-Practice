namespace Itmo.ObjectOrientedProgramming.Lab1;

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
            return new Failure("Train not created");
        }

        if (_partsOfRoute.Count == 0)
        {
            return new Failure("Route is empty");
        }

        int timeOfRoute = 0;

        while (_partsOfRoute.Count > 0)
        {
            PartOfRoute part = _partsOfRoute.Dequeue();
            Result intremediateResult = new Success(0);
            switch (part)
            {
                case NotPowerPath:
                    intremediateResult = _train.GoTroughPath(((NotPowerPath)part).Lenght);
                    break;
                case PowerPath:
                    intremediateResult = _train.ApplyForce(((PowerPath)part).Force);
                    if (intremediateResult is Failure)
                    {
                        Console.WriteLine(
                            $"Failure, message: {intremediateResult.ShowMessage()}.");
                        return intremediateResult;
                    }

                    intremediateResult = _train.GoTroughPath(((PowerPath)part).Lenght);
                    break;
                case Station:
                    _train.PassengersMoving(((Station)part).ReturnAmountOfPassangers());
                    intremediateResult = _train.SlowDown(((Station)part).ReturnLimitOfSpeed());
                    break;
            }

            if (intremediateResult is Failure)
            {
                Console.WriteLine(
                    $"Failure, message: {intremediateResult.ShowMessage()}.");
                return intremediateResult;
            }

            timeOfRoute += intremediateResult.ShowTimeOfRoute();

            _train.ResetSpeedBoost();
        }

        Result res = _train.SlowDown(_speedLimit);
        if (res is Success)
        {
            res = new Success(timeOfRoute);
            Console.WriteLine($"{res.ShowMessage()}. Time of route: {timeOfRoute}.");
            return res;
        }

        Console.WriteLine(
            $"Failure, message: {res.ShowMessage()}.");
        return res;
    }
}
