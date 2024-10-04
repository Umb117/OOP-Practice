namespace Itmo.ObjectOrientedProgramming.Lab1;

public record Station : PartOfRoute
{
    private int LimitOfSpeed { get; init; }

    private int AmountOfPassangers { get; init; }

    public Station(int limit, int passengers)
    {
        LimitOfSpeed = limit;
        AmountOfPassangers = passengers;
    }

    public int ReturnLimitOfSpeed()
    {
        return LimitOfSpeed;
    }

    public int ReturnAmountOfPassangers() { return AmountOfPassangers; }
}
