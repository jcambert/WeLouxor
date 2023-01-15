using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.InventaireArticle;

public interface ILigneInventaireAppService:IApplicationService
{
    Task<AddLigneInventaireResponse> AddAsync(IAddLigneInventaireQuery query);

    Task<GetLigneInventaireResponse> GetAsync(IGetLigneInventaireQuery query);

    Task<List<GetLigneInventaireResponse>> GetListAsync();

    Task<UpdateLigneInventaireResponse> UpdateAsync(IUpdateLigneInventaireQuery query);

    Task<RemoveLigneInventaireResponse> RemoveAsync(IRemoveLigneInventaireQuery query);

}
