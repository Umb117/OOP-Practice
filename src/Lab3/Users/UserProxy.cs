using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class UserProxy : IAdresee, IUser
{
    private readonly IUser _user;

    public string Name { get; init; }

    public IReadOnlyCollection<Message> UnReadMessages { get; init; }

    public IReadOnlyCollection<Message> ReadMessages { get; init; }

    private readonly int _minImportanceLevel;

    private readonly bool _logging;

    private readonly ILogger _logger;

    public UserProxy(IUser user, ILogger logger, int minImportanceLevel = 0, bool logging = false)
    {
        _user = user;
        Name = user.Name;
        UnReadMessages = user.UnReadMessages;
        ReadMessages = user.ReadMessages;
        _minImportanceLevel = minImportanceLevel;
        _logging = logging;
        _logger = logger;
    }

    public void GetMessage(Message message)
    {
        if (ImportanceFilter(message))
        {
            _user.GetMessage(message);
            if (_logging)
            {
                _logger.Log(message);
            }
        }
    }

    public Result ReadMessage()
    {
        Result result = _user.ReadMessage();
        return result;
    }

    private bool ImportanceFilter(Message message)
    {
        return _minImportanceLevel <= message.ImportanceLevel;
    }
}