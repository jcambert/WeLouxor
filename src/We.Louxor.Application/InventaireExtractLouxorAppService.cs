using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Mediatr;
using We.Results;

namespace We.Louxor;

public class InventaireExtractLouxorAppService
    : LouxorAppService,
      IInventaireExtractLouxorAppService
{
    public Task<Result<ClearArticleResponse>> Clear(ClearArticleQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<ClearCommandeClientResponse>> Clear(ClearCommandeClientQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<ClearOrdreDeFabricationResponse>> Clear(
        ClearOrdreDeFabricationQuery query
    ) => Mediator.Send(query).AsTaskWrap();

    public Task<Result<ClearClientResponse>> Clear(ClearClientQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<LoadCommandeClientResponse>> Load(LoadCommandeClientQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<LoadArticleResponse>> Load(LoadArticleQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<LoadOrdreDeFabricationResponse>> Load(LoadOrdreDeFabricationQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<LoadClientResponse>> Load(LoadClientQuery query) =>
        Mediator.Send(query).AsTaskWrap();
}
