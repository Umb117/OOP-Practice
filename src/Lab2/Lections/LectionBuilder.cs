namespace Itmo.ObjectOrientedProgramming.Lab2.Lections;

public class LectionBuilder : ILectionBuilder
{
    private string? _name;
    private string? _description;
    private string? _content;
    private int? _authorId;

    public ILectionBuilder AddName(string name)
    {
        _name = name;
        return this;
    }

    public ILectionBuilder AddDescription(string description)
    {
        _description = description;
        return this;
    }

    public ILectionBuilder AddContent(string content)
    {
        _content = content;
        return this;
    }

    public ILectionBuilder AddAuthorId(int? authorId)
    {
        _authorId = authorId;
        return this;
    }

    public ILection Build()
    {
        return new Lection(
            _name ?? throw new ArgumentNullException(),
            _description ?? throw new ArgumentNullException(),
            _content ?? throw new ArgumentNullException(),
            _authorId ?? throw new ArgumentNullException());
    }
}