using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class BrowseLigneInventaireHandler
    : BaseHandler<BrowseLigneInventaireQuery, BrowseLigneInventaireResponse>
{
    IRepository<LigneInventaire, Guid> repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();

    public BrowseLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override async Task<Result<BrowseLigneInventaireResponse>> InternalHandle(BrowseLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        var query = await repository.GetQueryableAsync();
        List<ILigneInventaire> res = await AsyncExecuter.ToListAsync<ILigneInventaire>(
            query,
            cancellationToken
        );
        var res1 = ObjectMapper.Map<List<ILigneInventaire>, List<LigneInventaireDto>>(res);
        return new BrowseLigneInventaireResponse(res1);
    }


}
