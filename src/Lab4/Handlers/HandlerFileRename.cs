using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerFileRename : HandlerBase
{
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public HandlerFileRename(ApplicationFileSystemContext fileSystemContext)
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

        if (request.Current is not "rename")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        if (request.MoveNext() is false)
            return null;

        string name = request.Current;

        ICommand command = new FileRenameCommand(_fileSystemContext, path, name);
        return command;
    }
}