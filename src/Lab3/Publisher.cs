namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Publisher
{
    public void PostMessage(Topic topic, Message message)
    {
        topic.SendToAdressees(message);
    }
}