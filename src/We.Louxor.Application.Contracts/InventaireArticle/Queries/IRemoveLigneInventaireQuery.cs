using System;

namespace We.Louxor.InventaireArticle.Queries;

public interface IRemoveLigneInventaireQuery:IInventaireQuery<RemoveLigneInventaire>
{
    Guid Id { get; set; }
}
public sealed record RemoveLigneInventaire():InventaireResponse;