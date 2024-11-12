using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    public string Name { get; init; }

    public Queue<Message> UnReadMessages { get; init; } = new();

    public Queue<Message> ReadMessages { get; init; } = new();

    public User(string name)
    {
        Name = name;
    }

    public Result ReadMessage()
    {
        if (UnReadMessages.Count != 0)
        {
            Message message = UnReadMessages.Dequeue();
            ReadMessages.Enqueue(message);
            return new Result.ReadSuccess();
        }

        return new Result.NoUnreadMessagesFail();
    }

    public void GetMessage(Message message)
    {
        UnReadMessages.Enqueue(message);
    }
}