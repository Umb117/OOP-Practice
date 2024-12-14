using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand, IEquatable<ConnectCommand>
{
    private readonly ApplicationFileSystemContext _fileSystemContext;
    private readonly string _mode;
    private readonly string _path;

    public ConnectCommand(ApplicationFileSystemContext fileSystemContext, string mode, string path)
    {
        _fileSystemContext = fileSystemContext;
        _mode = mode;
        _path = path;
    }

    public ResultType Execute()
    {
        IFileSystem? fileSystem = _mode switch
        {
            "local" => new LocalFileSystem(_path),
            _ => null,
        };

        if (fileSystem == null)
        {
            return new ResultType.NoSuchSystem();
        }

        _fileSystemContext.SetFileSystem(fileSystem);
        return new ResultType.Success("Successfully connected to local filesystem");
    }

    public override bool Equals(object? obj)
    {
        if (obj is ConnectCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public bool Equals(ConnectCommand? other)
    {
        if (other == null) return false;
        return _mode == other._mode && _path == other._path;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_mode, _path);
    }
}