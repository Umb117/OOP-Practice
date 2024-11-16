using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    private readonly IDisplay _display;

    public DisplayDriver(IDisplay display)
    {
        _display = display;
    }

    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void SetDisplayText(string text)
    {
        _display.SetDisplayText(text);
    }

    public void SetDisplayColor(Color color)
    {
        _display.Color = color;
    }

    public void PrintDisplayText()
    {
        ClearDisplay();
        _display.PrintText();
    }

    public void GetMessage(Message message)
    {
        _display.GetMessage(message);
    }
}