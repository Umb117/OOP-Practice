using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerConnect : HandlerBase
{
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public HandlerConnect(ApplicationFileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        request.MoveNext();
        if (request.Current is not "connect")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "-m")
            return null;

        if (request.MoveNext() is false)
            return null;

        ICommand command = new ConnectCommand(_fileSystemContext, request.Current, path);
        return command;
    }
}