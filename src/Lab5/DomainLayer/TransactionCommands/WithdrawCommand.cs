namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;

public class WithdrawCommand : ITransactionCommand
{
    public string Name { get; init;  }

    public IAccount Account { get; init; }

    public decimal Amount { get; init; }

    public WithdrawCommand(IAccount account, decimal amount)
    {
        Name = "Withdraw";
        Account = account;
        Amount = amount;
    }

    public Result Execute()
    {
        if (Amount < 0)
        {
            return new Result.WrongTransaction("Withdraw amount cannot be negative");
        }

        if (Account.Balance < Amount)
        {
            return new Result.NotEnoughMoney("Withdraw amount cannot be less than balance");
        }

        Account.ChangeBalance(-Amount);
        return new Result.Success();
    }
}