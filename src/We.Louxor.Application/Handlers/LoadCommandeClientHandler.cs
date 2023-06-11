using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadCommandeClientHandler
    : BaseLoadHandler<LoadCommandeClientQuery, LoadCommandeClientResponse, LigneDeCommande, Guid>
{
    public LoadCommandeClientHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override LoadCommandeClientResponse GetResponse() => new LoadCommandeClientResponse();
}
