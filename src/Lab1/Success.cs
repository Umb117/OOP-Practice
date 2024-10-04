namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Success : Result
{
    public Success(int time)
    {
        Message = "Successfully ended";
        TimeOfRoute = time;
    }
}