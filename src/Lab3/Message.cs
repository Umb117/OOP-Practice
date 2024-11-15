namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
    public string Name { get; init; }

    public string Text { get; init; }

    public int ImportanceLevel { get; init; }

    public Message(string name, string text, int importanceLevel)
    {
        Name = name;
        Text = text;
        ImportanceLevel = importanceLevel;
    }
}