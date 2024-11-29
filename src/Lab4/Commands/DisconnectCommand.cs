namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    private readonly IApplication _application;

    public DisconnectCommand(IApplication application)
    {
        _application = application;
    }

    public string Execute()
    {
        _application.SetFileSystem(null);
        return "Successfully disconnected from filesystem";
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
        return HashCode.Combine(_application);
    }

    private bool Equals(DisconnectCommand? other)
    {
        if (other == null) return false;
        return _application == other._application;
    }
}