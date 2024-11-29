using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.FileSystemStructure;

public class DirectoryFileSystemComponent : IFileSystemComponent
{
    public DirectoryFileSystemComponent(
        string name,
        IReadOnlyCollection<IFileSystemComponent> components)
    {
        Name = name;
        Components = components;
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemComponent> Components { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}