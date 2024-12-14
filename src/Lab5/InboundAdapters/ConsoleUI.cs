using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;

namespace Itmo.ObjectOrientedProgramming.Lab5.InboundAdapters;

public class ConsoleUI
{
    private readonly IAccountService _accountService;

    public ConsoleUI(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public void Run()
    {
        var menu = new MainMenu(_accountService);
        menu.Run();
    }
}