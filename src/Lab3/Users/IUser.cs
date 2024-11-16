using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    string Name { get; }

    IReadOnlyCollection<Message> UnReadMessages { get; }

    IReadOnlyCollection<Message> ReadMessages { get; }

    Result ReadMessage();

    void GetMessage(Message message);
}