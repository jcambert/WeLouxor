namespace We.Louxor.InventaireArticle.Queries;

public interface IBrowseOperationPourOrdreDeFabricationQuery
    : IInventaireQuery<BrowseOperationPourOrdreDeFabricationResponse>,
      ISociete
{
    int OrdreDeFabrication { get; set; }
}

public sealed record BrowseOperationPourOrdreDeFabricationResponse(List<int> Operations)
    : InventaireResponse;
