namespace apiservicosadm.tests.util_db;

public class CreateDatabase
{
    private readonly string _connectionString;
    private readonly string databaseName;

    public CreateDatabase(string connectionString, string databaseName)
    {
        _connectionString = connectionString;
        this.databaseName = databaseName;
    }

    public async Task Execute()
    {
        using var connection = new SqlConnection(_connectionString);
        var query = $"CREATE DATABASE {databaseName}";
        await connection.ExecuteAsync(query);
    }
}