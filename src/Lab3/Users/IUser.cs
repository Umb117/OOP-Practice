using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    string Name { get; }

    public Queue<Message> UnReadMessages { get; init; }

    public Queue<Message> ReadMessages { get; init; }

    public Result ReadMessage();

    void GetMessage(Message message);
}