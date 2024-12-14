using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
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
        ICommand expectedCommand = new ConnectCommand(app.FileSystem, "local", "C:\\");

        ICommand? command = app.ParseCommand(request);

        Assert.IsType<ConnectCommand>(command);
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
        ICommand expectedCommand = new DisconnectCommand(app.FileSystem);

        ICommand? command = app.ParseCommand(request);

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
        ICommand expectedCommand = new TreeGotocommand(app.FileSystem, "path");

        ICommand? command = app.ParseCommand(request);

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
        app.SetFileSystem(new ApplicationFileSystemContext(null));
        ICommand expectedCommand = new TreeListCommand(app.FileSystem, 3);

        ICommand? command = app.ParseCommand(request);

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
        app.SetFileSystem(new ApplicationFileSystemContext(new LocalFileSystem("global_path")));
        ICommand expectedCommand = new FileShowCommand(app.FileSystem, "console", "path");

        ICommand? command = app.ParseCommand(request);

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
        app.SetFileSystem(new ApplicationFileSystemContext(new LocalFileSystem("global_path")));
        ICommand expectedCommand = new FileMoveCommand(app.FileSystem, "sourcePath", "destinationPath");

        ICommand? command = app.ParseCommand(request);

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
        ICommand expectedCommand = new FileCopyCommand(app.FileSystem, "path1", "path2");

        ICommand? command = app.ParseCommand(request);

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
        ICommand expectedCommand = new FileDeleteCommand(app.FileSystem, "path");

        ICommand? command = app.ParseCommand(request);

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
        ICommand expectedCommand = new FileRenameCommand(app.FileSystem, "path", "name");

        ICommand? command = app.ParseCommand(request);

        Assert.IsType<FileRenameCommand>(command);
        if (command is not null)
            Assert.True(command.Equals(expectedCommand));
    }
}