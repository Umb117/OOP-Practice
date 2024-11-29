namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public string Execute()
    {
        var fileInfo = new FileInfo(_sourcePath);
        fileInfo.CopyTo(_destinationPath);
        return $"Successfully copy from {_sourcePath} to {_destinationPath}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is FileCopyCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_sourcePath, _destinationPath);
    }

    private bool Equals(FileCopyCommand? other)
    {
        if (other == null) return false;
        return _sourcePath == other._sourcePath && _destinationPath == other._destinationPath;
    }
}