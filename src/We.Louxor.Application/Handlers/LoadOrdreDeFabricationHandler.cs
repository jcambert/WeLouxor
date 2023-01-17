using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadOrdreDeFabricationHandler : BaseHandler<LoadOrdreDeFabricationQuery, LoadOrdreDeFabricationResponse>
{
    public LoadOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<LoadOrdreDeFabricationResponse> Handle(LoadOrdreDeFabricationQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
