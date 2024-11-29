using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public class HandlerFileShow : HandlerBase
{
    private readonly IApplication _application;

    public HandlerFileShow(IApplication application)
    {
        _application = application;
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

        if (request.Current is not "show")
        {
            request.Reset();
            return Next?.Handle(request);
        }

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        string? mode = null;
        if (request.MoveNext() is not false)
        {
            if (request.Current is not "-m")
                return null;

            if (request.MoveNext() is false)
                return null;

            mode = request.Current;
        }

        ICommand command = new FileShowCommand(_application, mode, path);
        return command;
    }
}