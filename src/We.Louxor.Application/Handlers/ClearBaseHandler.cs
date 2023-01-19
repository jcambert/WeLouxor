using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public abstract class ClearBaseHandler<TQuery, TResponse, TEntity, TKey> : BaseHandler<TQuery, TResponse>
     where TQuery : IClearBaseQuery, IRequest<TResponse>
    where TEntity : class, IEntity<TKey>
    where TResponse: new()
{
    IRepository<TEntity, TKey> Repository => LazyServiceProvider.GetRequiredService<IRepository<TEntity, TKey>>();
    protected ClearBaseHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
    {
        var query = await Repository.GetQueryableAsync();
        var ids = await AsyncExecuter.ToListAsync(query);
        await Repository.DeleteManyAsync(ids.Select(x=>x.Id), true, cancellationToken);
        return GetResponse();
    }
    protected virtual TResponse GetResponse() => new();
}
