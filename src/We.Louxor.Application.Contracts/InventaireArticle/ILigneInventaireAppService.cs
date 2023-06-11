using Volo.Abp.Application.Services;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.InventaireArticle;

public interface IInventaireAppService : IApplicationService
{
    Task<Result<AddLigneInventaireResponse>> AddAsync(AddLigneInventaireQuery query);

    Task<Result<GetLigneInventaireResponse>> GetAsync(GetLigneInventaireQuery query);

    Task<Result<BrowseLigneInventaireResponse>> GetListAsync(BrowseLigneInventaireQuery query);

    Task<Result<UpdateLigneInventaireResponse>> UpdateAsync(UpdateLigneInventaireQuery query);

    Task<Result<RemoveLigneInventaireResponse>> RemoveAsync(RemoveLigneInventaireQuery query);

    Task<Result<RemoveLigneInventaireResponse>> RemoveAllAsync(RemoveAllLigneInventaireQuery query);

    Task<Result<GetArticleResponse>> Get(GetArticleQuery query);

    Task<Result<BrowseArticleResponse>> Browse(BrowseArticleQuery query);

    Task<Result<BrowseOrdreDeFabricationResponse>> Browse(BrowseOrdreDeFabricationQuery query);

    Task<Result<BrowseOperationPourOrdreDeFabricationResponse>> Browse(
        BrowseOperationPourOrdreDeFabricationQuery query
    );
}
