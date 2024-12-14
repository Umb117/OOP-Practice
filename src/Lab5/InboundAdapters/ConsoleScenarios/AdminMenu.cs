using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.InboundAdapters;

public class AdminMenu : IMenu
{
    private readonly IAccountService _accountService;

    public AdminMenu(IAccountService initAccountService)
    {
        _accountService = initAccountService;
    }

    public void Run()
    {
        string systemPassword = AnsiConsole.Ask<string>("Введите [red]системный пароль[/]:");
        string hashedPassword = AccountService.HashPassword(systemPassword);

        Result result = _accountService.AuthenticateAdmin(hashedPassword);
        if (result is Result.Success)
        {
            AnsiConsole.MarkupLine("[green]Доступ предоставлен![/]");
            AnsiConsole.MarkupLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
            AnsiConsole.Clear();
            string actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices("Сменить пароль", "Назад"));
            switch (actionChoice)
            {
                case "Сменить пароль":
                    string newSystemPassword = AnsiConsole.Ask<string>("Введите новый пароль:");
                    string newHashedPassword = AccountService.HashPassword(newSystemPassword);
                    _accountService.ChangeAdminPassword(newHashedPassword);
                    AnsiConsole.MarkupLine("[green]Пароль удачно изменен[/]");
                    break;
                case "Назад":
                    return;
            }
        }
        else
        {
            if (result is Result.PasswordWrong)
            {
                AnsiConsole.MarkupLine($"[red]Пароль не верный.[/]");
                Environment.Exit(0);
            }

            AnsiConsole.MarkupLine($"[red]{result.Message}[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Нажмите любую клавишу для возврата в главное меню...[/]");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
}
