using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.InventaireArticle;

public interface IInventaireExtractLouxorAppService
{
    Task<Result<LoadCommandeClientResponse>> Load(LoadCommandeClientQuery query);

    Task<Result<LoadArticleResponse>> Load(LoadArticleQuery query);

    Task<Result<LoadOrdreDeFabricationResponse>> Load(LoadOrdreDeFabricationQuery query);
    Task<Result<LoadClientResponse>> Load(LoadClientQuery query);

    Task<Result<ClearArticleResponse>> Clear(ClearArticleQuery query);

    Task<Result<ClearCommandeClientResponse>> Clear(ClearCommandeClientQuery query);

    Task<Result<ClearOrdreDeFabricationResponse>> Clear(ClearOrdreDeFabricationQuery query);

    Task<Result<ClearClientResponse>> Clear(ClearClientQuery query);
}
