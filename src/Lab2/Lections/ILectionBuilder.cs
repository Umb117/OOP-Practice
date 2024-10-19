namespace Itmo.ObjectOrientedProgramming.Lab2.Lections;

public interface ILectionBuilder
{
    public ILectionBuilder AddName(string name);

    public ILectionBuilder AddDescription(string description);

    public ILectionBuilder AddContent(string content);

    public ILectionBuilder AddAuthorId(int? authorId);

    public ILection Build();
}