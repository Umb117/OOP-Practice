using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public abstract class HandlerBase : IHandler
{
    protected IHandler? Next { get; private set; }

    public IHandler AddNext(IHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract ICommand? Handle(IEnumerator<string> request);
}