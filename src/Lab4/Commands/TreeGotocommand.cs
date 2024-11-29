namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGotocommand : ICommand
{
    private readonly IApplication _application;
    private readonly string _path;

    public TreeGotocommand(IApplication application, string path)
    {
        _application = application;
        _path = path;
    }

    public string Execute()
    {
        _application.SetCurrentPath(_path);
        return $"Successfully go to {_path}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is TreeGotocommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_application, _path);
    }

    private bool Equals(TreeGotocommand? other)
    {
        if (other == null) return false;
        return _application == other._application && _path == other._path;
    }
}