using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;
using Moq;
using Xunit;

namespace Lab5.Tests;

public class AllLab5Tests
{
    [Fact]
    public void Deposit_Test_Success()
    {
        var account = new Account("accountNumber", "password");
        CurrentAccount.Account = account;
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransactionRepository>();
        var accountService = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ITransactionCommand depositCommand = accountService.CreateDepositCommand(5.00m);
        accountService.PerformTransaction(depositCommand);

        Assert.Equal(5.00m, accountService.GetBalance());
    }

    [Fact]
    public void Withdraw_Test_Success()
    {
        var account = new Account("accountNumber", "password");
        CurrentAccount.Account = account;
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransactionRepository>();
        var accountService = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ITransactionCommand depositCommand = accountService.CreateDepositCommand(5.00m);
        accountService.PerformTransaction(depositCommand);
        Deposit_Test_Success();
        ITransactionCommand withdrawCommand = accountService.CreateWithdrawCommand(2.00m);
        accountService.PerformTransaction(withdrawCommand);

        Assert.Equal(3.00m, accountService.GetBalance());
    }

    [Fact]
    public void WhenNegativeAmountInDepositCommandReturnFailure()
    {
        var account = new Account("accountNumber", "password");
        CurrentAccount.Account = account;
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransactionRepository>();
        var accountService = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ITransactionCommand depositCommand = accountService.CreateDepositCommand(-5.00m);
        Result result = accountService.PerformTransaction(depositCommand);

        Assert.IsType<Result.WrongTransaction>(result);
    }

    [Fact]
    public void WhenNegativeAmountInWithDrawCommandReturnFailure()
    {
        var account = new Account("accountNumber", "password");
        CurrentAccount.Account = account;
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransactionRepository>();
        var accountService = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ITransactionCommand withdrawCommand = accountService.CreateWithdrawCommand(-2.00m);
        Result result = accountService.PerformTransaction(withdrawCommand);

        Assert.IsType<Result.WrongTransaction>(result);
    }

    [Fact]
    public void WhenNotEnoughMoneyInWithDrawCommandReturnFailure()
    {
        var account = new Account("accountNumber", "password");
        CurrentAccount.Account = account;
        var accountRepositoryMock = new Mock<IAccountRepository>();
        var transactionRepositoryMock = new Mock<ITransactionRepository>();
        var accountService = new AccountService(accountRepositoryMock.Object, transactionRepositoryMock.Object);

        ITransactionCommand withdrawCommand = accountService.CreateWithdrawCommand(2.00m);
        Result result = accountService.PerformTransaction(withdrawCommand);

        Assert.IsType<Result.NotEnoughMoney>(result);
    }
}