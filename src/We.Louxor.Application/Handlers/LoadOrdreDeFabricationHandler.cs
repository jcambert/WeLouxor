using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadOrdreDeFabricationHandler : BaseLoadHandler<LoadOrdreDeFabricationQuery, LoadOrdreDeFabricationResponse,OrdreDeFabication,Guid>
{
    public LoadOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
    protected override List<OrdreDeFabication> Filter(List<OrdreDeFabication> records, bool removeDuplicates = false)
    =>records.Where(x => !string.IsNullOrEmpty(x.Societe) ).ToList();
}
