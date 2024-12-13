namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;

public interface ITransactionCommand
{
    string Name { get; }

    IAccount Account { get;  }

    decimal Amount { get; }

    Result Execute();
}