using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.InboundAdapters;

public class AccountMenu : IMenu
{
    private readonly IAccountService _accountService;

    public AccountMenu(IAccountService initAccountService)
    {
        _accountService = initAccountService;
    }

    public void Run()
    {
        while (true)
        {
            string actionChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .AddChoices("Просмотр баланса", "Снять деньги", "Начислить деньги", "История операций", "Назад"));

            AnsiConsole.Clear();
            switch (actionChoice)
            {
                case "Просмотр баланса":
                    AnsiConsole.WriteLine($"Ваш баланс: {_accountService.GetBalance()}");

                    break;
                case "Снять деньги":
                    decimal amount = AnsiConsole.Ask<decimal>("Введите сколько вы хотите снять:");
                    ITransactionCommand command = _accountService.CreateWithdrawCommand(amount);
                    Result result = _accountService.PerformTransaction(command);
                    if (result is Result.Success)
                    {
                        AnsiConsole.WriteLine("Баланс обновлен");
                        AnsiConsole.WriteLine($"Ваш баланс: {_accountService.GetBalance()}");
                    }
                    else
                    {
                        AnsiConsole.MarkupLine($"[red]{result.Message}[/]");
                    }

                    break;
                case "Начислить деньги":
                    amount = AnsiConsole.Ask<decimal>("Введите сколько вы хотите зачислить:");
                    command = _accountService.CreateDepositCommand(amount);
                    result = _accountService.PerformTransaction(command);
                    if (result is Result.Success)
                    {
                        AnsiConsole.WriteLine("Баланс обновлен");
                        AnsiConsole.WriteLine($"Ваш баланс: {_accountService.GetBalance()}");
                    }
                    else
                    {
                        AnsiConsole.MarkupLine($"[red]{result.Message}[/]");
                    }

                    break;
                case "История операций":
                    AnsiConsole.WriteLine(_accountService.GetHistory());
                    break;
                case "Назад":
                    return;
            }

            AnsiConsole.MarkupLine("[yellow]Нажмите любую клавишу для возврата...[/]");
            Console.ReadKey();
            AnsiConsole.Clear();
        }
    }
}