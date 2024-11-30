using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public FileMoveCommand(ApplicationFileSystemContext fileSystemContext, string sourcePath, string destinationPath)
    {
        _fileSystemContext = fileSystemContext;
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public Result Execute()
    {
        if (_fileSystemContext.FileSystem is not null)
        {
            _fileSystemContext.FileSystem.MoveTo(_sourcePath, _destinationPath);
            return new Result.Success($"Successfully moved {_sourcePath} to {_destinationPath}");
        }

        return new Result.NoFilesystemConnected();
    }

    public override bool Equals(object? obj)
    {
        if (obj is FileMoveCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_sourcePath, _destinationPath);
    }

    private bool Equals(FileMoveCommand? other)
    {
        if (other == null) return false;
        return _sourcePath == other._sourcePath && _destinationPath == other._destinationPath;
    }
}