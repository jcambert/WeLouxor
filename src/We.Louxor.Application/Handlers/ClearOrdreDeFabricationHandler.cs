using System;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class ClearOrdreDeFabricationHandler
    : ClearBaseHandler<
          ClearOrdreDeFabricationQuery,
          ClearOrdreDeFabricationResponse,
          OrdreDeFabication,
          Guid
      >
{
    public ClearOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }
}
