namespace We.Louxor.InventaireArticle.Queries;

public interface IBrowseLigneInventaireQuery : IInventaireQuery<BrowseLigneInventaireResponse>, ISociete
{
}

public sealed record BrowseLigneInventaireResponse(List<ILigneInventaire> Lignes) : InventaireResponse;