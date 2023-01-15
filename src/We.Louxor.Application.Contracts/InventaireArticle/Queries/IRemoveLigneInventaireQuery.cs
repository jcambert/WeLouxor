using System;

namespace We.Louxor.InventaireArticle.Queries;

public interface IRemoveLigneInventaireQuery:IInventaireQuery<RemoveLigneInventaireResponse>
{
    Guid Id { get; set; }
}
public sealed record RemoveLigneInventaireResponse():InventaireResponse;