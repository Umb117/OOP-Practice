namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    string Text { get; set; }

    void GetMessage(Message message);

    void PrintText();
}