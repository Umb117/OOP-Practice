using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;
using System.Security.Cryptography;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    private readonly ITransactionRepository _transactionRepository;

    public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public static string HashPassword(string password)
    {
        using var sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        var builder = new StringBuilder();
        foreach (byte b in bytes)
        {
            builder.Append(b.ToString("x2"));
        }

        return builder.ToString();
    }

    public Result AuthenticateAccount(string accountNumber, string hashedPassword)
    {
        IAccount? account = _accountRepository.FindAccountByNumber(accountNumber);
        if (account == null)
        {
            return new Result.AccountNotFound("Account not found");
        }

        if (account.HashedPassword != hashedPassword)
        {
            return new Result.PasswordWrong("Wrong Password");
        }

        CurrentAccount.Account = account;
        return new Result.Success();
    }

    public Result AuthenticateAdmin(string hashedAdminPassword)
    {
        if (Admin.IsPassword(hashedAdminPassword))
        {
            return new Result.Success();
        }

        return new Result.PasswordWrong("Wrong Password");
    }

    public Result CreateAccount(string accountNumber, string hashedPassword)
    {
        if (_accountRepository.CheckAccountNumberExists(accountNumber))
        {
            return new Result.AccountNotFound("Account not found");
        }

        var account = new Account(accountNumber, hashedPassword);
        _accountRepository.SaveAccount(account);
        return new Result.Success();
    }

    public Result PerformTransaction(ITransactionCommand command)
    {
        if (CurrentAccount.Account == null)
        {
            throw new ApplicationException("Current account is null, user not login");
        }

        Result result = command.Execute();
        if (result is Result.Success)
        {
            _transactionRepository.SaveTransaction(command);
            _accountRepository.UpdateAccount(CurrentAccount.Account);
        }

        return result;
    }

    public ITransactionCommand CreateDepositCommand(decimal amount)
    {
        if (CurrentAccount.Account == null)
        {
            throw new ApplicationException("Current account is null, user not login");
        }

        var command = new DepositCommand(CurrentAccount.Account, amount);
        return command;
    }

    public ITransactionCommand CreateWithdrawCommand(decimal amount)
    {
        if (CurrentAccount.Account == null)
        {
            throw new ApplicationException("Current account is null, user not login");
        }

        var command = new WithdrawCommand(CurrentAccount.Account, amount);
        return command;
    }

    public void ChangeAdminPassword(string newHashedPassword)
    {
        Admin.ChangePassword(newHashedPassword);
    }

    public decimal GetBalance()
    {
        if (CurrentAccount.Account == null)
        {
            throw new ApplicationException("Current account is null, user not login");
        }

        return CurrentAccount.Account.Balance;
    }

    public string GetHistory()
    {
        if (CurrentAccount.Account == null)
        {
            throw new ApplicationException("Current account is null, user not login");
        }

        string result = string.Empty;
        IList<string>? transactions = _transactionRepository.FindByAccountNumber(CurrentAccount.Account.AccountNumber);
        if (transactions is null)
        {
            return "No transactions found";
        }

        foreach (string transaction in transactions)
        {
            result += transaction + "\n";
        }

        return result;
    }
}