namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private string _text;

    public Messenger(string text)
    {
        _text = text;
    }

    public void PrintText()
    {
        Console.WriteLine("messanger: {0}", _text);
    }

    public void GetMessage(Message message)
    {
        _text = message.Text;
    }
}