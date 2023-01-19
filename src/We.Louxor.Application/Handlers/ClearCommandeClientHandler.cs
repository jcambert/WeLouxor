using System;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class ClearCommandeClientHandler : ClearBaseHandler<ClearCommandeClientQuery, ClearCommandeClientResponse, LigneDeCommande, Guid>
{
    public ClearCommandeClientHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
