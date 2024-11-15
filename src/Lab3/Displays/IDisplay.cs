using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    Color Color { get; set; }

    string Text { get; }

    public void SetDisplayText(string text);

    void PrintText();

    void GetMessage(Message message);
}