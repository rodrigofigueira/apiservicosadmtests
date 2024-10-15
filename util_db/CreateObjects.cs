namespace apiservicosadm.tests.util_db;

public class CreateObjects
{
    private readonly string _connectionString;

    public CreateObjects(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task Execute()
    {
        string directoryPath = AppDomain.CurrentDomain.BaseDirectory + @"\scripts";
        var files = Directory.GetFiles(directoryPath, "*.txt")
                             .OrderBy(f => f)
                             .ToList();

        using var connection = new SqlConnection(_connectionString);

        foreach (var file in files)
        {
            string sqlQuery = File.ReadAllText(file);
            await connection.ExecuteAsync(sqlQuery);
        }
    }
}
