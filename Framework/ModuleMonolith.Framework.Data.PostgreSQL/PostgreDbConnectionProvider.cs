using Npgsql;
using System.Data.Common;

namespace ModuleMonolith.Framework.Data.PostgreSQL;
internal class PostgreDbConnectionProvider(string connectionString) : IDbConnectionProvider
{
    private DbConnection? _connection;

    public DbConnection DbConnection
    {
        get
        {
            if (_connection is null)
            {
                _connection = new NpgsqlConnection(connectionString);
                _connection.Open();
            }

            return _connection;
        }
    }

    public void Dispose() => _connection?.Dispose();
    public ValueTask DisposeAsync() => _connection?.DisposeAsync() ?? ValueTask.CompletedTask;
}
