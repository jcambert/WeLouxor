using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface IClearCommandeClientQuery
    : IClearBaseQuery<ClearCommandeClientResponse>,
      IInventaireQuery<ClearCommandeClientResponse> { }

public sealed record ClearCommandeClientResponse() : Response;
