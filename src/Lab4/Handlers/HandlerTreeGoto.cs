using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerTreeGoto : HandlerBase
{
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public HandlerTreeGoto(ApplicationFileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        request.MoveNext();
        if (request.Current is not "tree")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "goto")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        ICommand command = new TreeGotocommand(_fileSystemContext, path);
        return command;
    }
}