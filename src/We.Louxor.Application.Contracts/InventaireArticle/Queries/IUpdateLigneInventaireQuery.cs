using System;

namespace We.Louxor.InventaireArticle.Queries;

public interface IUpdateLigneInventaireQuery : IInventaireQuery<UpdateLigneInventaireResponse>
{
    Guid Id { get; set; }
    LigneInventaireDto Ligne { get; set; }
}
public sealed record UpdateLigneInventaireResponse(LigneInventaireDto Ligne):InventaireResponse;

