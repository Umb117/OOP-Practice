namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public string Text { get; set; }

    public Messenger(string text)
    {
        Text = text;
    }

    public void PrintText()
    {
        Console.WriteLine("messanger: {0}", Text);
    }

    public void GetMessage(Message message)
    {
        Text = message.Text;
    }
}