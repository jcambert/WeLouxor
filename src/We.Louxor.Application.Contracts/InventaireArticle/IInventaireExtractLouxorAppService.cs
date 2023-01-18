using System.Threading.Tasks;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.InventaireArticle;

public interface IInventaireExtractLouxorAppService
{
    Task<LoadCommandeClientResponse> Load(LoadCommandeClientQuery query);

    Task<LoadArticleResponse> Load(LoadArticleQuery query);

    Task<LoadOrdreDeFabricationResponse> Load(LoadOrdreDeFabricationQuery query);

    Task<ClearArticleResponse> Clear(ClearArticleQuery query);

    Task<ClearCommandeClientResponse> Clear(ClearCommandeClientQuery query);

    Task<ClearOrdreDeFabricationResponse> Clear(ClearOrdreDeFabricationQuery query);
}
