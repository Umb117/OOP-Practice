using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    Color Color { get; }

    string Text { get; }

    void SetDisplayText(string text);

    public void SetDisplayColor(Color color);

    void PrintText();

    void GetMessage(Message message);
}