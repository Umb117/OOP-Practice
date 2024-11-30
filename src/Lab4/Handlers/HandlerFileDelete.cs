using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerFileDelete : HandlerBase
{
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public HandlerFileDelete(ApplicationFileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        request.MoveNext();
        if (request.Current is not "file")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
            return null;

        if (request.Current is not "delete")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        request.MoveNext();
        string path = request.Current;

        ICommand command = new FileDeleteCommand(_fileSystemContext, path);
        return command;
    }
}