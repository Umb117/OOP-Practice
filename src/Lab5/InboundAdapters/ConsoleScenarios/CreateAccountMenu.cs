using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.InboundAdapters;

public class CreateAccountMenu : IMenu
{
    private readonly IAccountService _accountService;

    public CreateAccountMenu(IAccountService initAccountService)
    {
        _accountService = initAccountService;
    }

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Введите [green]имя пользователя[/]:");
        string password = AnsiConsole.Ask<string>("Введите [red]пароль[/]:");
        string hashedPassword = AccountService.HashPassword(password);

        Result result = _accountService.CreateAccount(username, hashedPassword);
        if (result is Result.Success)
        {
            AnsiConsole.MarkupLine("[blue]Аккаунт успешно создан![/]");
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