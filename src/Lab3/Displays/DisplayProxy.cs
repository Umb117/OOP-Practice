using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayProxy : IDisplayDriver, IAdresee
{
    private readonly IDisplayDriver _displayDriver;

    public bool Logging { get; set; }

    public ILogger Logger { get; set; }

    public int MinImportanceLevel { get; set; }

    public DisplayProxy(IDisplayDriver displayDriver, ILogger logger, int minImportanceLevel = 0, bool logging = false)
    {
        _displayDriver = displayDriver;
        MinImportanceLevel = minImportanceLevel;
        Logging = logging;
        Logger = logger;
    }

    public void ClearDisplay()
    {
        _displayDriver.ClearDisplay();
    }

    public void SetDisplayText(string text)
    {
        _displayDriver.SetDisplayText(text);
    }

    public void SetDisplayColor(Color color)
    {
        _displayDriver.SetDisplayColor(color);
    }

    public void PrintDisplayText()
    {
        _displayDriver.PrintDisplayText();
    }

    public void GetMessage(Message message)
    {
        if (ImportanceFilter(message))
        {
            _displayDriver.GetMessage(message);
            if (Logging)
            {
                Logger.Log(message);
            }
        }
    }

    private bool ImportanceFilter(Message message)
    {
        return MinImportanceLevel <= message.ImportanceLevel;
    }
}