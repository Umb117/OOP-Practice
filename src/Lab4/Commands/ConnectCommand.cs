using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand, IEquatable<ConnectCommand>
{
    private readonly IApplication _application;
    private readonly string _mode;
    private readonly string _path;

    public ConnectCommand(IApplication application, string mode, string path)
    {
        _application = application;
        _mode = mode;
        _path = path;
    }

    public string Execute()
    {
        IFileSystem fileSystem = _mode switch
        {
            "local" => new LocalFileSystem(_path),
            _ => new LocalFileSystem(_path),
        };

        _application.SetFileSystem(fileSystem);
        return "Successfully connected to local filesystem";
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
        return _application == other._application && _mode == other._mode && _path == other._path;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_application, _mode, _path);
    }
}