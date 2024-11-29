using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerTreeList : HandlerBase
{
    private readonly IApplication _application;

    public HandlerTreeList(IApplication application)
    {
        _application = application;
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

        if (request.Current is not "list")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        int depthInt = 1;
        if (request.MoveNext() is not false)
        {
            string depth = request.Current;
            depthInt = int.Parse(depth);
        }

        ICommand command = new TreeListCommand(_application.CurrentPath, _application.FileSystem?.Path, depthInt);
        return command;
    }
}