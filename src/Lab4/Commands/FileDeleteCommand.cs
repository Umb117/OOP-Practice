namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public string Execute()
    {
        var fileInfo = new FileInfo(_path);
        fileInfo.Delete();
        return $"Successfully deleted {_path}";
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