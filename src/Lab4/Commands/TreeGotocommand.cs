using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotocommand : ICommand
{
    private readonly ApplicationFileSystemContext _fileSystemContext;
    private readonly string _path;

    public TreeGotocommand(ApplicationFileSystemContext fileSystemContext, string path)
    {
        _fileSystemContext = fileSystemContext;
        _path = path;
    }

    public Result Execute()
    {
        if (_fileSystemContext.FileSystem is not null)
        {
            _fileSystemContext.FileSystem.SetCurrentPath(_path);
            return new Result.Success($"Successfully go to {_path}");
        }

        return new Result.NoFilesystemConnected();
    }

    public override bool Equals(object? obj)
    {
        if (obj is TreeGotocommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path);
    }

    private bool Equals(TreeGotocommand? other)
    {
        if (other == null) return false;
        return _path == other._path;
    }
}