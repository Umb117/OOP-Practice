namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class MessengerProxy : IAdresee, IMessenger
{
    private readonly IMessenger _messenger;

    private readonly int _minImportanceLevel;

    private readonly bool _logging;

    private readonly ILogger _logger;

    public MessengerProxy(IMessenger messenger, ILogger logger, int minImportanceLevel = 0, bool logging = false)
    {
        _messenger = messenger;
        _minImportanceLevel = minImportanceLevel;
        _logging = logging;
        _logger = logger;
    }

    public void GetMessage(Message message)
    {
        if (ImportanceFilter(message))
        {
            _messenger.GetMessage(message);
            if (_logging)
            {
                _logger.Log(message);
            }
        }
    }

    public void PrintText()
    {
       _messenger.PrintText();
    }

    private bool ImportanceFilter(Message message)
    {
        return _minImportanceLevel <= message.ImportanceLevel;
    }
}