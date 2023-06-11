using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadCommandeClientQuery
    : ILoadBaseQuery<LoadCommandeClientResponse>,
      IInventaireQuery<LoadCommandeClientResponse> { }

public sealed record LoadCommandeClientResponse():Response;
