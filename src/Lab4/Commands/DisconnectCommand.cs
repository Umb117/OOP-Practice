using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public DisconnectCommand(ApplicationFileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public Result Execute()
    {
        _fileSystemContext.SetFileSystem(null);
        return new Result.Success("Successfully disconnected from filesystem");
    }

    public override bool Equals(object? obj)
    {
        if (obj is DisconnectCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_fileSystemContext);
    }

    private bool Equals(DisconnectCommand? other)
    {
        if (other == null) return false;
        return _fileSystemContext == other._fileSystemContext;
    }
}