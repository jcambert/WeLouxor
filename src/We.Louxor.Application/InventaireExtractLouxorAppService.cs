using System.Threading.Tasks;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor;

public class InventaireExtractLouxorAppService : LouxorAppService, IInventaireExtractLouxorAppService
{
    public Task<ClearArticleResponse> Clear(ClearArticleQuery query)
    => Mediator.Send(query);

    public Task<ClearCommandeClientResponse> Clear(ClearCommandeClientQuery query)
   => Mediator.Send(query);

    public Task<ClearOrdreDeFabricationResponse> Clear(ClearOrdreDeFabricationQuery query)
    => Mediator.Send(query);

    public Task<ClearClientResponse> Clear(ClearClientQuery query)
    => Mediator.Send(query);

    public Task<LoadCommandeClientResponse> Load(LoadCommandeClientQuery query)
    => Mediator.Send(query);

    public Task<LoadArticleResponse> Load(LoadArticleQuery query)
    => Mediator.Send(query);

    public Task<LoadOrdreDeFabricationResponse> Load(LoadOrdreDeFabricationQuery query)
    => Mediator.Send(query);

    public Task<LoadClientResponse> Load(LoadClientQuery query)
    => Mediator.Send(query);
}
