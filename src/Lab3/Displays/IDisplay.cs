using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    Color Color { get; set; }

    string Text { get; set; }

    void PrintText();

    void GetMessage(Message message);
}