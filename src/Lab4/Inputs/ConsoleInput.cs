namespace Itmo.ObjectOrientedProgramming.Lab4.Inputs;

public class ConsoleInput : IInput
{
    public IEnumerable<string> GetArgs()
    {
        string? str = Console.ReadLine();
        if (str != null)
        {
            return str.Split(" ");
        }

        return Array.Empty<string>();
    }
}