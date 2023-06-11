using We.Mediatr;

namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadArticleQuery
    : ILoadBaseQuery<LoadArticleResponse>,
      IInventaireQuery<LoadArticleResponse> { }

public sealed record LoadArticleResponse() : Response;
