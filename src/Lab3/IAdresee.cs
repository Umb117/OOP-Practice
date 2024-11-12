namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IAdresee
{
    public int MinImportanceLevel { get; set; }

    public bool Logging { get; set; }

    public ILogger Logger { get; set; }

    public void GetMessage(Message message);
}