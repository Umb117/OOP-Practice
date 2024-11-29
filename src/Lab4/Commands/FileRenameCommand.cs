namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public string Execute()
    {
        var fileInfo = new FileInfo(_path);
        string? dirName = Path.GetDirectoryName(_path);
        if (dirName is not null)
        {
            string newPath = Path.Combine(dirName, _name);
            fileInfo.MoveTo(newPath);
            return $"Successfully renamed {_path} to {newPath}";
        }

        fileInfo.MoveTo(_name);
        return $"Successfully renamed {_path} to {_name}";
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