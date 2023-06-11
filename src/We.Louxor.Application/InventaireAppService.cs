using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Mediatr;
using We.Results;

namespace We.Louxor;

public class InventaireAppService : LouxorAppService, IInventaireAppService
{
    public Task<Result<AddLigneInventaireResponse>> AddAsync(AddLigneInventaireQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<GetLigneInventaireResponse>> GetAsync(GetLigneInventaireQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<BrowseLigneInventaireResponse>> GetListAsync(
        BrowseLigneInventaireQuery query
    ) => Mediator.Send(query).AsTaskWrap();

    public Task<Result<RemoveLigneInventaireResponse>> RemoveAsync(
        RemoveLigneInventaireQuery query
    ) => Mediator.Send(query).AsTaskWrap();

    public Task<Result<RemoveLigneInventaireResponse>> RemoveAllAsync(
        RemoveAllLigneInventaireQuery query
    ) => Mediator.Send(query).AsTaskWrap();

    public Task<Result<UpdateLigneInventaireResponse>> UpdateAsync(
        UpdateLigneInventaireQuery query
    ) => Mediator.Send(query).AsTaskWrap();

    public Task<Result<GetArticleResponse>> Get(GetArticleQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<BrowseArticleResponse>> Browse(BrowseArticleQuery query) =>
        Mediator.Send(query).AsTaskWrap();

    public Task<Result<BrowseOrdreDeFabricationResponse>> Browse(
        BrowseOrdreDeFabricationQuery query
    ) => Mediator.Send(query).AsTaskWrap();

    public Task<Result<BrowseOperationPourOrdreDeFabricationResponse>> Browse(
        BrowseOperationPourOrdreDeFabricationQuery query
    ) => Mediator.Send(query).AsTaskWrap();
}
