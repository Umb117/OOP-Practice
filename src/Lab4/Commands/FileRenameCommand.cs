using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public FileRenameCommand(ApplicationFileSystemContext fileSystemContext, string path, string name)
    {
        _fileSystemContext = fileSystemContext;
        _path = path;
        _name = name;
    }

    public ResultType Execute()
    {
        if (_fileSystemContext.FileSystem is not null)
        {
            _fileSystemContext.FileSystem.Rename(_path, _name);
            return new ResultType.Success($"Successfully renamed");
        }

        return new ResultType.NoFilesystemConnected();
    }

    public override bool Equals(object? obj)
    {
        if (obj is FileRenameCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_path, _name);
    }

    private bool Equals(FileRenameCommand? other)
    {
        if (other == null) return false;
        return _path == other._path && _name == other._name;
    }
}