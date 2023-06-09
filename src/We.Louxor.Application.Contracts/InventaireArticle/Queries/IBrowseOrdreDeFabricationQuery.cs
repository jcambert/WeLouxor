namespace We.Louxor.InventaireArticle.Queries;

public interface IBrowseOrdreDeFabricationQuery
    : IInventaireQuery<BrowseOrdreDeFabricationResponse>,
      ISociete { }

public sealed record BrowseOrdreDeFabricationResponse(
    List<BrowseOrdreDeFabricationForCompletion> Ofs
);

public sealed record BrowseOrdreDeFabricationForCompletion
{
    public int Numero { get; init; }
    public string CodeArticle { get; init; }

    public string Repr => $"{Numero}-{CodeArticle}";
}
