using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Logger : ILogger
{
    public void Log(Message message)
    {
        Console.WriteLine("{0}: {1}", DateTime.Now.ToString(CultureInfo.CurrentCulture), message);
    }
}