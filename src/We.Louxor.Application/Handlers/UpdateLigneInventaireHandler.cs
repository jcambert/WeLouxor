using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class UpdateLigneInventaireHandler
    : BaseHandler<UpdateLigneInventaireQuery, UpdateLigneInventaireResponse>
{
    protected IRepository<LigneInventaire, Guid> _inv_repository =>
        LazyServiceProvider.LazyGetRequiredService<IRepository<LigneInventaire, Guid>>();

    public UpdateLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    public override async Task<UpdateLigneInventaireResponse> Handle(
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
        return new UpdateLigneInventaireResponse(null);
    }
}
