using Itmo.ObjectOrientedProgramming.Lab4.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShowCommand : ICommand
{
    private readonly IApplication _application;
    private readonly string? _mode;
    private readonly string _path;

    public FileShowCommand(IApplication application, string? mode, string path)
    {
        _application = application;
        _mode = mode;
        _path = path;
    }

    public string Execute()
    {
        if (_mode is not null)
        {
            IOutput output = _mode switch
            {
                "console" => new ConsoleOutput(),
                _ => new ConsoleOutput(),
            };
            _application.SetOutput(output);
        }

        string res = string.Empty;
        using StreamReader sr = File.OpenText(_path);
        while (sr.ReadLine() is { } s)
        {
            res += s;
            res += "\n";
        }

        return res;
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
        return HashCode.Combine(_application, _mode, _path);
    }

    private bool Equals(FileShowCommand? other)
    {
        if (other == null) return false;
        return _application == other._application && _mode == other._mode && _path == other._path;
    }
}