using System.Data.Common;

namespace ModuleMonolith.Framework.Data;

public interface IDbConnectionProvider : IDisposable, IAsyncDisposable
{
    DbConnection DbConnection { get; }
}
