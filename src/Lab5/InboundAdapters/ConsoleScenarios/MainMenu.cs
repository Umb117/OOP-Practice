using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.InboundAdapters;

public class MainMenu : IMenu
{
    private readonly IAccountService _accountService;

    public MainMenu(IAccountService initAccountService)
    {
        _accountService = initAccountService;
    }

    public void Run()
    {
        while (true)
        {
            string mainChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices("Войти в аккаунт", "Создать аккаунт", "Я админ"));

            switch (mainChoice)
            {
                case "Войти в аккаунт":
                    AnsiConsole.Clear();
                    new LoginMenu(_accountService).Run();
                    break;
                case "Создать аккаунт":
                    AnsiConsole.Clear();
                    new CreateAccountMenu(_accountService).Run();
                    break;
                case "Я админ":
                    AnsiConsole.Clear();
                    new AdminMenu(_accountService).Run();
                    break;
            }
        }
    }
}