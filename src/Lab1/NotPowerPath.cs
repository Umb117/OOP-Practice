namespace Itmo.ObjectOrientedProgramming.Lab1;

public record NotPowerPath : PartOfRoute
{
    public int Lenght { get; init; }

    public NotPowerPath(int lenght) { Lenght = lenght; }
}
