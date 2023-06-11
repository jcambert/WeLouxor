using System;

namespace We.Louxor.InventaireArticle.Queries;

public interface IGetLigneInventaireQuery : IInventaireQuery<GetLigneInventaireResponse>
{
    Guid Id { get; set; }
}

public sealed record GetLigneInventaireResponse(LigneInventaireDto Ligne) : InventaireResponse;
