using System.Data.Common;

namespace ModuleMonolith.Framework.Data;

internal class DbTransactionProvider(IDbConnectionProvider dbConnectionProvider) : IDbTransactionProvider
{
    private DbTransaction? _transaction;

    public DbTransaction Transaction => _transaction ??= dbConnectionProvider.DbConnection.BeginTransaction();

    public bool IsTransactionStarted => _transaction is not null;

    public void Dispose() => _transaction?.Dispose();

    public ValueTask DisposeAsync() => _transaction?.DisposeAsync() ?? ValueTask.CompletedTask;
}
