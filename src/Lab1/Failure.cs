namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Failure : Result
{
    public Failure(string message)
    {
        Message = message;
        TimeOfRoute = 0;
    }
}