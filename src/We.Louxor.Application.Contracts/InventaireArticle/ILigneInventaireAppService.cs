using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.InventaireArticle;

public interface IInventaireAppService:IApplicationService
{
    Task<AddLigneInventaireResponse> AddAsync(AddLigneInventaireQuery query);

    Task<GetLigneInventaireResponse> GetAsync(GetLigneInventaireQuery query);

    Task<List<GetLigneInventaireResponse>> GetListAsync();

    Task<UpdateLigneInventaireResponse> UpdateAsync(UpdateLigneInventaireQuery query);

    Task<RemoveLigneInventaireResponse> RemoveAsync(RemoveLigneInventaireQuery query);

}
