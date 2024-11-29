using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Inputs;
using Itmo.ObjectOrientedProgramming.Lab4.Outputs;
using Xunit;

namespace Lab4.Tests;

public class AllLab4Tests
{
    [Fact]
    public void ConnectCommandTestSuccess()
    {
        IEnumerable<string> args = ["connect", "C:\\", "-m", "local"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new ConnectCommand(app, "local", "C:\\");

        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void DisconnectCommandTestSuccess()
    {
        IEnumerable<string> args = ["disconnect"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new DisconnectCommand(app);

        Assert.IsType<DisconnectCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void TreeGotoCommandTestSuccess()
    {
        IEnumerable<string> args = ["tree", "goto", "path"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new TreeGotocommand(app, "path");

        Assert.IsType<TreeGotocommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void TreeListCommandTestSuccess()
    {
        IEnumerable<string> args = ["tree", "list", "3"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);
        app.SetCurrentPath("path");

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new TreeListCommand("path", null, 3);

        Assert.IsType<TreeListCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void FileShowCommandTestSuccess()
    {
        IEnumerable<string> args = ["file", "show", "path", "-m", "console"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);
        app.SetCurrentPath("path");

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new FileShowCommand(app, "console", "path");

        Assert.IsType<FileShowCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void FileMoveCommandTestSuccess()
    {
        IEnumerable<string> args = ["file", "move", "sourcePath", "destinationPath"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);
        app.SetCurrentPath("path");

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new FileMoveCommand("sourcePath", "destinationPath");

        Assert.IsType<FileMoveCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void FileCopyCommandTestSuccess()
    {
        IEnumerable<string> args = ["file", "copy", "path1", "path2"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new FileCopyCommand("path1", "path2");

        Assert.IsType<FileCopyCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void FileDeleteCommandTestSuccess()
    {
        IEnumerable<string> args = ["file", "delete", "path"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new FileDeleteCommand("path");

        Assert.IsType<FileDeleteCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }

    [Fact]
    public void FileRenameCommandTestSuccess()
    {
        IEnumerable<string> args = ["file", "rename", "path", "name"];
        using IEnumerator<string> request = args.GetEnumerator();
        IInput input = new ConsoleInput();
        IOutput output = new ConsoleOutput();
        var app = new Application(input, output);

        ICommand? command = app.ParseCommand(request);
        ICommand expectedCommand = new FileRenameCommand("path", "name");

        Assert.IsType<FileRenameCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }
}