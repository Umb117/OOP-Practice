using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}