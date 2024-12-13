namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;

public interface IAccount
{
    string AccountNumber { get; }

    string HashedPassword { get; }

    decimal Balance { get; }

    void ChangeBalance(decimal amount);
}