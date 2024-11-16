using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    public string Name { get; init; }

    public IReadOnlyCollection<Message> UnReadMessages => _unReadMessages.ToList().AsReadOnly();

    public IReadOnlyCollection<Message> ReadMessages => _readMessages.ToList().AsReadOnly();

    private readonly Queue<Message> _unReadMessages = new();
    private readonly Queue<Message> _readMessages = new();

    public User(string name)
    {
        Name = name;
    }

    public Result ReadMessage()
    {
        if (UnReadMessages.Count != 0)
        {
            Message message = _unReadMessages.Dequeue();
            _readMessages.Enqueue(message);
            return new Result.ReadSuccess();
        }

        return new Result.NoUnreadMessagesFail();
    }

    public void GetMessage(Message message)
    {
        _unReadMessages.Enqueue(message);
    }
}