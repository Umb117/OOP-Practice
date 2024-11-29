using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerFileDelete : HandlerBase
{
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

        ICommand command = new FileDeleteCommand(path);
        return command;
    }
}