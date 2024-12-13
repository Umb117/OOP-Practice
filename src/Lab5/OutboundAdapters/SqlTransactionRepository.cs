using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.Ports;
using Itmo.ObjectOrientedProgramming.Lab5.DomainLayer.TransactionCommands;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.OutboundAdapters;

public class SqlTransactionRepository : ITransactionRepository, IDisposable
{
    private readonly NpgsqlConnection _connection;

    public SqlTransactionRepository(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        CreateTableIfNotExists();
    }

    public void SaveTransaction(ITransactionCommand transactionCommand)
    {
        _connection.Open();
        string accountNumber = transactionCommand.Account.AccountNumber;
        decimal amount = transactionCommand.Amount;
        string type = transactionCommand.Name;
        using var command = new NpgsqlCommand(
            "INSERT INTO transactions (account_number, amount, transaction_type) VALUES (@account_number, @amount, @transaction_type)",
            _connection);
        command.Parameters.AddWithValue("account_number", accountNumber);
        command.Parameters.AddWithValue("amount", amount);
        command.Parameters.AddWithValue("transaction_type", type);
        command.ExecuteNonQuery();
        _connection.Close();
    }

    public IList<string>? FindByAccountNumber(string accountNumber)
    {
        _connection.Open();
        using var command = new NpgsqlCommand(
            "SELECT account_number, amount, transaction_type FROM transactions WHERE account_number = @account_number",
            _connection);
        command.Parameters.AddWithValue("account_number", accountNumber);

        using NpgsqlDataReader reader = command.ExecuteReader();
        var result = new List<string>();
        while (reader.Read())
        {
            string accNumber = reader.GetString(0);
            decimal amount = reader.GetDecimal(1);
            string transactionType = reader.GetString(2);

            result.Add($"{accNumber}, {amount}, {transactionType}");
        }

        if (result.Count > 0)
        {
            _connection.Close();
            return result;
        }

        _connection.Close();
        return null;
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
                "CREATE TABLE IF NOT EXISTS transactions (account_number VARCHAR(50) NOT NULL, amount DECIMAL(10, 2) NOT NULL, transaction_type VARCHAR(50) NOT NULL)";
            command.ExecuteNonQuery();
        }

        _connection.Close();
    }
}