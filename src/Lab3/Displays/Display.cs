using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    public Color Color { get; private set; }

    public string Text { get; private set; }

    public Display(string text = "")
    {
        Color = Color.White;
        Text = text;
    }

    public void PrintText()
    {
        Console.WriteLine(Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(Text));
        using var sw = new StreamWriter("display.txt", false);
        sw.WriteLine(Text);
        sw.Close();
    }

    public void SetDisplayText(string text)
    {
        Text = text;
    }

    public void SetDisplayColor(Color color)
    {
        Color = color;
    }

    public void GetMessage(Message message)
    {
        Text = message.Text;
    }
}