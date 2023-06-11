using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadOrdreDeFabricationHandler
    : BaseLoadHandler<
          LoadOrdreDeFabricationQuery,
          LoadOrdreDeFabricationResponse,
          OrdreDeFabication,
          Guid
      >
{
    public LoadOrdreDeFabricationHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override LoadOrdreDeFabricationResponse GetResponse() =>
        new LoadOrdreDeFabricationResponse();
}
