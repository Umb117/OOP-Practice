using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayProxy : IDisplayDriver, IAdresee
{
    private readonly IDisplayDriver _displayDriver;

    private readonly int _minImportanceLevel;

    private readonly bool _logging;

    private readonly ILogger _logger;

    public DisplayProxy(IDisplayDriver displayDriver, ILogger logger, int minImportanceLevel = 0, bool logging = false)
    {
        _displayDriver = displayDriver;
        _minImportanceLevel = minImportanceLevel;
        _logging = logging;
        _logger = logger;
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
            if (_logging)
            {
                _logger.Log(message);
            }
        }
    }

    private bool ImportanceFilter(Message message)
    {
        return _minImportanceLevel <= message.ImportanceLevel;
    }
}