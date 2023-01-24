namespace We.Louxor.InventaireArticle.Queries;

public interface IBrowseOperationPourOrdreDeFabricationQuery : IInventaireQuery<BrowseOperationPourOrdreDeFabricationResponse>, ISociete
{
    string OrdreDeFabrication { get; set; }
}

public sealed record BrowseOperationPourOrdreDeFabricationResponse(List<string> Operations) : InventaireResponse;