using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface IClearClientQuery
    : IClearBaseQuery<ClearClientResponse>,
      IInventaireQuery<ClearClientResponse> { }

public sealed record ClearClientResponse() : Response;
