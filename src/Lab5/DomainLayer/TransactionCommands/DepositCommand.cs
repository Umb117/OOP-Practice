namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;

public class DepositCommand : ITransactionCommand
{
    public string Name { get; init;  }

    public IAccount Account { get; init; }

    public decimal Amount { get; init; }

    public DepositCommand(IAccount account, decimal amount)
    {
        Name = "Deposit";
        Account = account;
        Amount = amount;
    }

    public Result Execute()
    {
        if (Amount < 0)
        {
            return new Result.WrongTransaction("Deposit amount cannot be negative");
        }

        Account.ChangeBalance(Amount);
        return new Result.Success();
    }
}