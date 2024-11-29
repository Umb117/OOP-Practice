using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly string _path;
    private readonly int _depth;

    public TreeListCommand(string? currPath, string? fileSystemPath, int depth)
    {
        _path = currPath ?? fileSystemPath ?? Directory.GetCurrentDirectory();
        _depth = depth;
    }

    public string Execute()
    {
        var factory = new FileSystemComponentFactory();
        IFileSystemComponent component = factory.Create(_path);

        var visitor = new OutputVisitor(_depth);

        component.Accept(visitor);
        string res = visitor.Text;
        return res;
    }

    public override bool Equals(object? obj)
    {
        if (obj is TreeListCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path, _depth);
    }

    private bool Equals(TreeListCommand? other)
    {
        if (other == null) return false;
        return _path == other._path && _depth == other._depth;
    }
}