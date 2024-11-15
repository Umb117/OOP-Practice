using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    private IDisplay Display { get; init; }

    public DisplayDriver(IDisplay display)
    {
        Display = display;
    }

    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void SetDisplayText(string text)
    {
        Display.SetDisplayText(text);
    }

    public void SetDisplayColor(Color color)
    {
        Display.Color = color;
    }

    public void PrintDisplayText()
    {
        ClearDisplay();
        Display.PrintText();
    }

    public void GetMessage(Message message)
    {
        Display.GetMessage(message);
    }
}