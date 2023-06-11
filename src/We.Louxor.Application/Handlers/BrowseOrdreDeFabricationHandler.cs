using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class BrowseOrdreDeFabricationHandler
    : BaseHandler<BrowseOrdreDeFabricationQuery, BrowseOrdreDeFabricationResponse>
{
    protected IRepository<OrdreDeFabication, Guid> repository =>
        LazyServiceProvider.GetRequiredService<IRepository<OrdreDeFabication, Guid>>();

    public BrowseOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override async Task<Result<BrowseOrdreDeFabricationResponse>> InternalHandle(
        BrowseOrdreDeFabricationQuery request,
        CancellationToken cancellationToken
    )
    {
        var query = await repository.GetQueryableAsync();
        query = from q in query where q.Societe == request.Societe select q;
        var res = await AsyncExecuter.ToListAsync<IOrdreDeFabication>(query, cancellationToken);
        var ress = res.Select(x => (x.Numero, x.CodeArticle))
            .Distinct()
            .Select(
                x =>
                    new BrowseOrdreDeFabricationForCompletion()
                    {
                        Numero = x.Numero,
                        CodeArticle = x.CodeArticle
                    }
            )
            .ToList();
        return new BrowseOrdreDeFabricationResponse(ress);
    }
}
