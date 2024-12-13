namespace Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;

public interface IAccountRepository
{
    void SaveAccount(IAccount account);

    IAccount? FindAccountByNumber(string number);

    bool CheckAccountNumberExists(string number);

    void UpdateAccount(IAccount account);
}