using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    public void ClearDisplay();

    public void SetDisplayText(string text);

    public void SetDisplayColor(Color color);

    public void PrintDisplayText();

    public void GetMessage(Message message);
}