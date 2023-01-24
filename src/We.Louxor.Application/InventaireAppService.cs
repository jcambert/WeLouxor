using System.Collections.Generic;
using System.Threading.Tasks;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor;
public class InventaireAppService : LouxorAppService, IInventaireAppService
{
    public Task<AddLigneInventaireResponse> AddAsync(AddLigneInventaireQuery query)
    => Mediator.Send(query);

    public Task<GetLigneInventaireResponse> GetAsync(GetLigneInventaireQuery query)
    => Mediator.Send(query);

    public Task<BrowseLigneInventaireResponse> GetListAsync(BrowseLigneInventaireQuery query)
     => Mediator.Send(query);

    public Task<RemoveLigneInventaireResponse> RemoveAsync(RemoveLigneInventaireQuery query)
    => Mediator.Send(query);

    public Task<RemoveLigneInventaireResponse> RemoveAllAsync(RemoveAllLigneInventaireQuery query)
   => Mediator.Send(query);

    public Task<UpdateLigneInventaireResponse> UpdateAsync(UpdateLigneInventaireQuery query)
    => Mediator.Send(query);

    public Task<GetArticleResponse> Get(GetArticleQuery query)
    =>Mediator.Send(query);

    public Task<BrowseArticleResponse> Browse(BrowseArticleQuery query)
   => Mediator.Send(query);

    public Task<BrowseOrdreDeFabricationResponse> Browse(BrowseOrdreDeFabricationQuery query)
        => Mediator.Send(query);

    public Task<BrowseOperationPourOrdreDeFabricationResponse> Browse(BrowseOperationPourOrdreDeFabricationQuery query)
        => Mediator.Send(query);
}
