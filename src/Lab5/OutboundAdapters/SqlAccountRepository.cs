using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.OutboundAdapters;

public class SqlAccountRepository : IAccountRepository, IDisposable
{
    private readonly NpgsqlConnection _connection;

    public SqlAccountRepository(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        CreateTableIfNotExists();
    }

    public void SaveAccount(IAccount account)
    {
        _connection.Open();
        string accountNumber = account.AccountNumber;
        string passwordHash = account.HashedPassword;
        using var command = new NpgsqlCommand(
            "INSERT INTO accounts (account_number, password_hash) VALUES (@account_number, @password_hash)",
            _connection);
        command.Parameters.AddWithValue("account_number", accountNumber);
        command.Parameters.AddWithValue("password_hash", passwordHash);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public IAccount? FindAccountByNumber(string number)
    {
        _connection.Open();
        using var command = new NpgsqlCommand(
            "SELECT account_number, password_hash FROM accounts WHERE account_number = @account_number",
            _connection);
        command.Parameters.AddWithValue("account_number", number);
        command.ExecuteNonQuery();

        using NpgsqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            string accountNumber = reader.GetString(0);
            string passwordHash = reader.GetString(1);

            _connection.Close();
            return new Account(accountNumber, passwordHash);
        }

        _connection.Close();
        return null;
    }

    public bool CheckAccountNumberExists(string number)
    {
        _connection.Open();
        using var command = new NpgsqlCommand(
            "SELECT account_number FROM accounts WHERE account_number = @account_number",
            _connection);
        command.Parameters.AddWithValue("account_number", number);
        command.ExecuteNonQuery();

        using NpgsqlDataReader reader = command.ExecuteReader();
        bool res = reader.Read();

        _connection.Close();
        return res;
    }

    public void UpdateAccount(IAccount account)
    {
        Console.WriteLine("Updating account");
        _connection.Open();
        string accountNumber = account.AccountNumber;
        decimal newBalance = account.Balance;
        Console.WriteLine(newBalance);
        using var command = new NpgsqlCommand(
            "UPDATE accounts SET balance = @balance WHERE account_number = @account_number",
            _connection);
        command.Parameters.AddWithValue("balance", newBalance);
        command.Parameters.AddWithValue("account_number", accountNumber);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public void Dispose()
    {
        _connection.Dispose();
    }

    private void CreateTableIfNotExists()
    {
        _connection.Open();
        using (NpgsqlCommand command = _connection.CreateCommand())
        {
            command.CommandText =
                "CREATE TABLE IF NOT EXISTS accounts (account_number VARCHAR(50) NOT NULL,password_hash VARCHAR(255) NOT NULL,balance DECIMAL(10, 2) NOT NULL DEFAULT 0.00)";
            command.ExecuteNonQuery();
        }

        _connection.Close();
    }
}