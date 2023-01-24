using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.InventaireArticle;

public interface IInventaireAppService:IApplicationService
{
    Task<AddLigneInventaireResponse> AddAsync(AddLigneInventaireQuery query);

    Task<GetLigneInventaireResponse> GetAsync(GetLigneInventaireQuery query);

    Task<BrowseLigneInventaireResponse> GetListAsync(BrowseLigneInventaireQuery query);

    Task<UpdateLigneInventaireResponse> UpdateAsync(UpdateLigneInventaireQuery query);

    Task<RemoveLigneInventaireResponse> RemoveAsync(RemoveLigneInventaireQuery query);

    Task<RemoveLigneInventaireResponse> RemoveAllAsync(RemoveAllLigneInventaireQuery query);

    Task<GetArticleResponse> Get(GetArticleQuery query);

    Task<BrowseArticleResponse> Browse(BrowseArticleQuery query);

    Task<BrowseOrdreDeFabricationResponse> Browse(BrowseOrdreDeFabricationQuery query);

    Task<BrowseOperationPourOrdreDeFabricationResponse> Browse(BrowseOperationPourOrdreDeFabricationQuery query);
    
}
