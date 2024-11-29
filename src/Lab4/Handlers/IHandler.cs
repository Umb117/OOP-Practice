using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Handlers;

public interface IHandler
{
    IHandler AddNext(IHandler handler);

    ICommand? Handle(IEnumerator<string> request);
}