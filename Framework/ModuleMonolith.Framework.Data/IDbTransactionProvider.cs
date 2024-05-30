using System.Data.Common;

namespace ModuleMonolith.Framework.Data;

public interface IDbTransactionProvider : IDisposable, IAsyncDisposable
{
    DbTransaction Transaction { get; }
    bool IsTransactionStarted { get; }
}
