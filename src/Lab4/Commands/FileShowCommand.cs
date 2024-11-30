using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly string? _mode;
    private readonly string _path;
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public FileShowCommand(ApplicationFileSystemContext fileSystemContext, string? mode, string path)
    {
        _fileSystemContext = fileSystemContext;
        _mode = mode;
        _path = path;
    }

    public ResultType Execute()
    {
        if (_fileSystemContext.FileSystem is not null)
        {
            string res = _fileSystemContext.FileSystem.ReadAllText(_path);
            return new ResultType.Success(res);
        }

        return new ResultType.NoFilesystemConnected();
    }

    public override bool Equals(object? obj)
    {
        if (obj is FileShowCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_mode, _path);
    }

    private bool Equals(FileShowCommand? other)
    {
        if (other == null) return false;
        return _mode == other._mode && _path == other._path;
    }
}