using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface IClearArticleQuery
    : IClearBaseQuery<ClearArticleResponse>,
      IInventaireQuery<ClearArticleResponse> { }

public sealed record ClearArticleResponse() : Response;
