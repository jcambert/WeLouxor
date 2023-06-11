using Volo.Abp.Domain.Entities;
using We.Louxor.InventaireArticle.Queries;
using We.Mediatr;
using We.Results;

namespace We.Louxor.Handlers;

public abstract class ClearBaseHandler<TQuery, TResponse, TEntity, TKey>
    : BaseHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>, IClearBaseQuery
    where TResponse : Response
    where TEntity : class, IEntity<TKey>, IEntityLouxor
{
    IRepository<TEntity, TKey> Repository =>
        LazyServiceProvider.GetRequiredService<IRepository<TEntity, TKey>>();

    protected ClearBaseHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override async  Task<Result<TResponse>> InternalHandle(TQuery request, CancellationToken cancellationToken)
    {
        await Repository.HardDeleteAsync(
           x => x.Societe == request.Societe,
           true,
           cancellationToken
       );
        return GetResponse();
    }


    protected abstract TResponse GetResponse();
}
