using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.InboundAdapters;

public class LoginMenu : IMenu
{
    private readonly IAccountService _accountService;

    public LoginMenu(IAccountService initAccountService)
    {
        _accountService = initAccountService;
    }

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Введите [green]имя пользователя[/]:");
        string password = AnsiConsole.Ask<string>("Введите [red]пароль[/]:");

        Result result = _accountService.AuthenticateAccount(username, password);
        if (result is Result.Success)
        {
            AnsiConsole.Clear();
            new AccountMenu(_accountService).Run();
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]{result.Message}[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Нажмите любую клавишу для возврата в главное меню...[/]");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
}