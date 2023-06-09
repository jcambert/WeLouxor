namespace We.Louxor.InventaireArticle.Queries;

public interface IClearCommandeClientQuery
    : IClearBaseQuery,
      IInventaireQuery<ClearCommandeClientResponse> { }

public sealed record ClearCommandeClientResponse();
