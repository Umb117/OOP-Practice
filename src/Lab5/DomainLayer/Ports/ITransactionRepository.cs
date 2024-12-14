using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;

public interface ITransactionRepository
{
    void SaveTransaction(ITransactionCommand transactionCommand);

    IList<string>? FindByAccountNumber(string accountNumber);
}