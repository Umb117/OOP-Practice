namespace Itmo.ObjectOrientedProgramming.Lab2.Lections;

public class Lection : ILection, IPrototype<Lection>
{
    private static int _generalId;
    private readonly int _id;

    public int? OriginalId { get; init; }

    private readonly int _authorId;
    private string _name;
    private string _description;
    private string _content;

    public Lection(string name, string description, string content, int authorId, int? originalId = null)
    {
        _id = _generalId;
        _name = name;
        _description = description;
        _content = content;
        _authorId = authorId;
        OriginalId = originalId;
        _generalId++;
    }

    public Lection Clone()
    {
        return new Lection(_name, _description, _content, _authorId, _id);
    }

    public void Edit(int id, string? newName, string? newDescription, string? newContent)
    {
        if (!IsAutor(id)) return;

        if (newName == null && newDescription == null && newContent == null) return;

        if (newName != null) EditName(newName);
        if (newDescription != null) EditDescription(newDescription);
        if (newContent != null) EditContent(newContent);
    }

    private void EditName(string newName)
    {
        _name = newName;
    }

    private void EditDescription(string newDescription)
    {
        _description = newDescription;
    }

    private void EditContent(string newContent)
    {
        _content = newContent;
    }

    private bool IsAutor(int id)
    {
        return _authorId == id;
    }
}