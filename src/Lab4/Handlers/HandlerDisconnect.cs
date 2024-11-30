using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerDisconnect : HandlerBase
{
    private readonly ApplicationFileSystemContext _fileSystemContext;

    public HandlerDisconnect(ApplicationFileSystemContext fileSystemContext)
    {
        _fileSystemContext = fileSystemContext;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        request.MoveNext();
        if (request.Current is not "disconnect")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        var command = new DisconnectCommand(_fileSystemContext);

        return command;
    }
}