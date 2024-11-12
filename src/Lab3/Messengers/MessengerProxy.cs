namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class MessengerProxy : IAdresee, IMessenger
{
    private readonly IMessenger _messenger;

    public string Text { get; set; }

    public int MinImportanceLevel { get; set; }

    public bool Logging { get; set; }

    public ILogger Logger { get; set; }

    public MessengerProxy(IMessenger messenger, ILogger logger, int minImportanceLevel = 0, bool logging = false)
    {
        _messenger = messenger;
        Text = messenger.Text;
        MinImportanceLevel = minImportanceLevel;
        Logging = logging;
        Logger = logger;
    }

    public void GetMessage(Message message)
    {
        if (ImportanceFilter(message))
        {
            _messenger.GetMessage(message);
            if (Logging)
            {
                Logger.Log(message);
            }
        }
    }

    public void PrintText()
    {
       _messenger.PrintText();
    }

    private bool ImportanceFilter(Message message)
    {
        return MinImportanceLevel <= message.ImportanceLevel;
    }
}