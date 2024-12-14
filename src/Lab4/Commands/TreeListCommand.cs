using Itmo.ObjectOrientedProgramming.Lab4.Results;
using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.TreeGoTo.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeListCommand : ICommand
{
    private readonly string? _path;
    private readonly int _depth;
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public TreeListCommand(ApplicationFileSystemContext fileSystemContext, int depth)
    {
        _fileSystemContext = fileSystemContext;
        _path = _fileSystemContext.FileSystem?.CurrentPath ?? _fileSystemContext.FileSystem?.GlobalPath;
        _depth = depth;
    }

    public ResultType Execute()
    {
        var factory = new FileSystemComponentFactory();
        if (_path != null)
        {
            IFileSystemComponent component = factory.Create(_path);
            var visitor = new OutputVisitor(_depth);

            component.Accept(visitor);
            string res = visitor.Text;
            return new ResultType.Success(res);
        }

        return new ResultType.NoFilesystemConnected();
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