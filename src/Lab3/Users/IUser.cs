using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser
{
    string Name { get; }

    public IReadOnlyCollection<Message> UnReadMessages { get; }

    public IReadOnlyCollection<Message> ReadMessages { get; }

    public Result ReadMessage();

    void GetMessage(Message message);
}