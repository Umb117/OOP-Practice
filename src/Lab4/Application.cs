using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Inputs;
using Itmo.ObjectOrientedProgramming.Lab4.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Application : IApplication
{
    private readonly IInput _input;
    private readonly IHandler _parser;

    public IFileSystem? FileSystem { get; private set; }

    public string? CurrentPath { get; private set; }

    public IOutput Output { get; private set; }

    public Application(IInput input, IOutput output)
    {
        _input = input;
        Output = output;
        IHandler handler = new HandlerConnect(this).AddNext(new HandlerDisconnect(this).AddNext(
            new HandlerTreeGoto(this).AddNext(new HandlerTreeList(this).AddNext(
                new HandlerFileShow(this).AddNext(new HandlerFileMove().AddNext(
                    new HandlerFileCopy().AddNext(new HandlerFileDelete().AddNext(new HandlerFileRename()))))))));
        _parser = handler;
    }

    public void Work()
    {
        while (true)
        {
            IEnumerable<string> args = _input.GetArgs();
            using IEnumerator<string> request = args.GetEnumerator();
            ICommand? comm = ParseCommand(request);
            Output.Print(comm != null ? comm.Execute() : "No such command");
        }
    }

    public ICommand? ParseCommand(IEnumerator<string> request)
    {
        ICommand? comm = _parser.Handle(request);
        return comm;
    }

    public void SetFileSystem(IFileSystem? fileSystem)
    {
        FileSystem = fileSystem;
    }

    public void SetCurrentPath(string path)
    {
        CurrentPath = path;
    }

    public void SetOutput(IOutput output)
    {
        Output = output;
    }
}