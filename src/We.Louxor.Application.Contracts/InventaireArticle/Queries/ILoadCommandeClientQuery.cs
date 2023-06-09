namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadCommandeClientQuery
    : ILoadBaseQuery,
      IInventaireQuery<LoadCommandeClientResponse> { }

public sealed record LoadCommandeClientResponse();
