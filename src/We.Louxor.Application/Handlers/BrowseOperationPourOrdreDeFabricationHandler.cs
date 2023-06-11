using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class BrowseOperationPourOrdreDeFabricationHandler
    : BaseHandler<
          BrowseOperationPourOrdreDeFabricationQuery,
          BrowseOperationPourOrdreDeFabricationResponse
      >
{
    IRepository<OrdreDeFabication, Guid> repository =>
        LazyServiceProvider.GetRequiredService<IRepository<OrdreDeFabication, Guid>>();

    public BrowseOperationPourOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override async Task<
        Result<BrowseOperationPourOrdreDeFabricationResponse>
    > InternalHandle(
        BrowseOperationPourOrdreDeFabricationQuery request,
        CancellationToken cancellationToken
    )
    {
        var query = await repository.GetQueryableAsync();
        var of = request.OrdreDeFabrication;
        var of1 = of * 1000;
        var of2 = of * 1000 + 999;
        query = from q in query where q.Societe == request.Societe && q.Numero == of select q;

        var list = await AsyncExecuter.ToListAsync(query, cancellationToken);

        var res = list.Select(x => x.CodeOperation).Order().ToList();
        return new BrowseOperationPourOrdreDeFabricationResponse(res);
    }
}
