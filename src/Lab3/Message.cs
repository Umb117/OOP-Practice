namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message
{
    public string Name { get; set; }

    public string Text { get; set; }

    public int ImportanceLevel { get; set; }

    public Message(string name, string text, int importanceLevel)
    {
        Name = name;
        Text = text;
        ImportanceLevel = importanceLevel;
    }
}