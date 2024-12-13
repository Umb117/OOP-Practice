using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;

public interface IAccountService
{
    Result CreateAccount(string accountNumber, string hashedPassword);

    Result AuthenticateAdmin(string hashedAdminPassword);

    Result AuthenticateAccount(string accountNumber, string hashedPassword);

    Result PerformTransaction(ITransactionCommand command);

    ITransactionCommand CreateDepositCommand(decimal amount);

    ITransactionCommand CreateWithdrawCommand(decimal amount);

    void ChangeAdminPassword(string newHashedPassword);

    decimal GetBalance();

    string GetHistory();
}