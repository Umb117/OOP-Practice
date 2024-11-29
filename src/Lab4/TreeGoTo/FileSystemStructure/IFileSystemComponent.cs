using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.FileSystemStructure;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}