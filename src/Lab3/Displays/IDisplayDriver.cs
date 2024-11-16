using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    void ClearDisplay();

    void SetDisplayText(string text);

    void SetDisplayColor(Color color);

    void PrintDisplayText();

    void GetMessage(Message message);
}