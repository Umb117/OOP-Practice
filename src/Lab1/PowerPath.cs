namespace Itmo.ObjectOrientedProgramming.Lab1;

public record PowerPath : PartOfRoute
{
    public int Lenght { get; init; }

    public int Force { get; init; }

    public PowerPath(int lenght, int force)
    {
        Lenght = lenght;
        Force = force;
    }
}
