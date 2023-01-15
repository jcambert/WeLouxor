using System.Collections.Generic;
using System.Threading.Tasks;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor;

public class LigneInventaireAppService : LouxorAppService, ILigneInventaireAppService
{
    public Task<AddLigneInventaireResponse> AddAsync(IAddLigneInventaireQuery query)
    => Mediator.Send(query);

    public Task<GetLigneInventaireResponse> GetAsync(IGetLigneInventaireQuery query)
    => Mediator.Send(query);

    public Task<List<GetLigneInventaireResponse>> GetListAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<RemoveLigneInventaireResponse> RemoveAsync(IRemoveLigneInventaireQuery query)
    => Mediator.Send(query);

    public Task<UpdateLigneInventaireResponse> UpdateAsync(IUpdateLigneInventaireQuery query)
    => Mediator.Send(query);
}
