using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class UpdateLigneInventaireHandler
    : BaseHandler<UpdateLigneInventaireQuery, UpdateLigneInventaireResponse>
{
    protected IRepository<LigneInventaire, Guid> _inv_repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();

    public UpdateLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override async Task<Result<UpdateLigneInventaireResponse>> InternalHandle(
        UpdateLigneInventaireQuery request,
        CancellationToken cancellationToken
    )
    {
        //request.Ligne
        var row = await _inv_repository.SingleOrDefaultAsync(x => x.Id == request.Id);
        if (row != null)
        {
            ObjectMapper.Map(request.Ligne, row);
            var res = await _inv_repository.UpdateAsync(row);
            return new UpdateLigneInventaireResponse(
                ObjectMapper.Map<LigneInventaire, LigneInventaireDto>(res)
            );
        }
        return NotFound("Npt Founc", $"La ligne d'inventaire avec l'id {request.Id} n'existe pas");
    }
}
