using MediatR;
using Volo.Abp.Domain.Entities;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public abstract class ClearBaseHandler<TQuery, TResponse, TEntity, TKey>
    : BaseHandler<TQuery, TResponse>
    where TQuery : IClearBaseQuery, IRequest<TResponse>
    where TEntity : class, IEntity<TKey>, IEntityLouxor
    where TResponse : new()
{
    IRepository<TEntity, TKey> Repository =>
        LazyServiceProvider.GetRequiredService<IRepository<TEntity, TKey>>();

    protected ClearBaseHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task<TResponse> Handle(
        TQuery request,
        CancellationToken cancellationToken
    )
    {
        await Repository.HardDeleteAsync(
            x => x.Societe == request.Societe,
            true,
            cancellationToken
        );
        return GetResponse();
    }

    protected virtual TResponse GetResponse() => new();
}
