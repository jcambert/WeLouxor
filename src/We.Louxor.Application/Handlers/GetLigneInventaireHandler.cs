using Volo.Abp.Domain.Repositories;
using We.AbpExtensions;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class GetLigneInventaireHandler
    :AbpHandler.With<GetLigneInventaireQuery, GetLigneInventaireResponse,LigneInventaire,LigneInventaireDto>
{
    public GetLigneInventaireHandler(IAbpLazyServiceProvider serviceProvider)
        : base(serviceProvider) { }

    protected override async Task<Result<GetLigneInventaireResponse>> InternalHandle(GetLigneInventaireQuery request, CancellationToken cancellationToken)
    {
        var res = await Repository.FirstAsync(x=>x.Id==request.Id);
        if (res == null)
            return NotFound($"Not Found","Aucune ligne d'inventaire n'existe avec l'id {request.Id}");
        return new GetLigneInventaireResponse(MapToDto(res));
        
    }
}
