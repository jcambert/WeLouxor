namespace We.Louxor.InventaireArticle.Queries;

public interface IBrowseOrdreDeFabricationQuery
    : IInventaireQuery<BrowseOrdreDeFabricationResponse>,
      ISociete { }

public sealed record BrowseOrdreDeFabricationResponse(
    List<BrowseOrdreDeFabricationForCompletion> Ofs
) : InventaireResponse;

public sealed record BrowseOrdreDeFabricationForCompletion
{
    public int Numero { get; init; }
    public string CodeArticle { get; init; } = string.Empty;

    public string Repr => $"{Numero}-{CodeArticle}";
}
