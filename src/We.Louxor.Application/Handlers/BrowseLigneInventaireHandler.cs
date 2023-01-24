using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class BrowseLigneInventaireHandler : BaseHandler<BrowseLigneInventaireQuery, BrowseLigneInventaireResponse>
{
    IRepository<LigneInventaire, Guid> repository => LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();
    public BrowseLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<BrowseLigneInventaireResponse> Handle(BrowseLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        var query=await repository.GetQueryableAsync();
        List<ILigneInventaire> res =await AsyncExecuter.ToListAsync<ILigneInventaire>(query, cancellationToken);
        
        return new BrowseLigneInventaireResponse(res);
    }
}
