using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public FileDeleteCommand(ApplicationFileSystemContext fileSystemContext, string path)
    {
        _fileSystemContext = fileSystemContext;
        _path = path;
    }

    public ResultType Execute()
    {
        if (_fileSystemContext.FileSystem is not null)
        {
            _fileSystemContext.FileSystem.Delete(_path);
            return new ResultType.Success($"Successfully deleted {_path}");
        }

        return new ResultType.NoFilesystemConnected();
    }

    public override bool Equals(object? obj)
    {
        if (obj is FileDeleteCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path);
    }

    private bool Equals(FileDeleteCommand? other)
    {
        if (other == null) return false;
        return _path == other._path;
    }
}