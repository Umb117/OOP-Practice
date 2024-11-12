using Itmo.ObjectOrientedProgramming.Lab3.Results;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class UserProxy : IAdresee, IUser
{
    private readonly IUser _user;

    public string Name { get; }

    public Queue<Message> UnReadMessages { get; init; }

    public Queue<Message> ReadMessages { get; init; }

    public int MinImportanceLevel { get; set; }

    public bool Logging { get; set; }

    public ILogger Logger { get; set; }

    public UserProxy(IUser user, ILogger logger, int minImportanceLevel = 0, bool logging = false)
    {
        _user = user;
        Name = user.Name;
        UnReadMessages = user.UnReadMessages;
        ReadMessages = user.ReadMessages;
        MinImportanceLevel = minImportanceLevel;
        Logging = logging;
        Logger = logger;
    }

    public void GetMessage(Message message)
    {
        if (ImportanceFilter(message))
        {
            _user.GetMessage(message);
            if (Logging)
            {
                Logger.Log(message);
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
        return MinImportanceLevel <= message.ImportanceLevel;
    }
}