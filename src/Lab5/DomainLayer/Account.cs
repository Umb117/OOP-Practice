namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;

public class Account : IAccount
{
    public string AccountNumber { get; init; }

    public string HashedPassword { get; init; }

    public decimal Balance { get; private set; }

    public Account(string accountNumber, string hashedPassword)
    {
        AccountNumber = accountNumber;
        HashedPassword = hashedPassword;
        Balance = 0.00m;
    }

    public void ChangeBalance(decimal amount)
    {
        Balance += amount;
    }
}