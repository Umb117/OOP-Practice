using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Inputs;
using Itmo.ObjectOrientedProgramming.Lab4.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Application : IApplication
{
    private readonly IInput _input;
    private readonly IHandler _parser;

    public ApplicationFileSystemContext FileSystem { get; private set; }

    public IOutput Output { get; private set; }

    public Application(IInput input, IOutput output)
    {
        _input = input;
        Output = output;
        FileSystem = new ApplicationFileSystemContext(null);
        IHandler handler = new HandlerConnect(FileSystem).AddNext(new HandlerDisconnect(FileSystem).AddNext(
            new HandlerTreeGoto(FileSystem).AddNext(new HandlerTreeList(FileSystem).AddNext(
                new HandlerFileShow(FileSystem).AddNext(new HandlerFileMove(FileSystem).AddNext(
                    new HandlerFileCopy(FileSystem).AddNext(new HandlerFileDelete(FileSystem).AddNext(new HandlerFileRename(FileSystem)))))))));
        _parser = handler;
    }

    public void Work()
    {
        while (true)
        {
            IEnumerable<string> args = _input.GetInput();
            using IEnumerator<string> request = args.GetEnumerator();
            ICommand? command = ParseCommand(request);
            if (command is null)
            {
                Output.Print("No such command");
                continue;
            }

            ResultType resultType = command.Execute();
            if (resultType is ResultType.Success)
            {
                Output.Print(((ResultType.Success)resultType).Text);
            }
        }
    }

    public ICommand? ParseCommand(IEnumerator<string> request)
    {
        ICommand? comm = _parser.Handle(request);
        return comm;
    }

    public void SetFileSystem(ApplicationFileSystemContext fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void SetOutput(IOutput output)
    {
        Output = output;
    }
}