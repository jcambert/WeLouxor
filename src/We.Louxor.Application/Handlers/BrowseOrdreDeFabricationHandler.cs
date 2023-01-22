using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class BrowseOrdreDeFabricationHandler : BaseHandler<BrowseOrdreDeFabricationQuery, BrowseOrdreDeFabricationResponse>
{
    protected IRepository<OrdreDeFabication, Guid> repository => LazyServiceProvider.GetRequiredService<IRepository<OrdreDeFabication, Guid>>();
    public BrowseOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<BrowseOrdreDeFabricationResponse> Handle(BrowseOrdreDeFabricationQuery request, CancellationToken cancellationToken)
    {
        var query = await repository.GetQueryableAsync();
        query = from q in query where q.Societe == request.Societe  select q;
        var res = await AsyncExecuter.ToListAsync(query, cancellationToken);

        List<int> ress = new();
        ress.AddRange(res.Select(x=>x.Numero).Distinct().OrderBy(x=>x));
        return new BrowseOrdreDeFabricationResponse(ress);
    }
}
