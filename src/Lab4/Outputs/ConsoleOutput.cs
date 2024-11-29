namespace Itmo.ObjectOrientedProgramming.Lab4.Outputs;

public class ConsoleOutput : IOutput
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}