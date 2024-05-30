using ErrorOr;
using MediatR;
using ModuleMonolith.Framework.Data;
using ModuleMonolith.Framework.UseCases;

namespace ModuleMonolith.Web;

public class DbTransactionPipelineBehavior<TRequest, TResponse>(IDbTransactionProvider dbTransactionProvider)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ITransactional
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (dbTransactionProvider.IsTransactionStarted)
            return await next();

        await using var transaction = dbTransactionProvider.Transaction;

        try
        {
            TResponse result = default!;

            result = await next();

            if (result is IErrorOr errorOr && errorOr.IsError)
                await transaction.RollbackAsync(cancellationToken);
            else
                await transaction.CommitAsync(cancellationToken);

            return result;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync(cancellationToken);

            return (TResponse)(object)ErrorOr<TResponse>.From([Error.Failure()]);
        }
        finally
        {
            await transaction.DisposeAsync();
        }
    }
}