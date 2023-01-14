namespace We.Louxor.InventaireArticle.Queries;

public interface IAddLigneInventaireQuery:IInventaireQuery<AddLigneInventaireResponse>
{
    ILigneInventaire Ligne { get; set; }
}

public sealed record AddLigneInventaireResponse(ILigneInventaire Ligne):InventaireResponse;