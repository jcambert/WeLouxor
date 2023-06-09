namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadArticleQuery : ILoadBaseQuery, IInventaireQuery<LoadArticleResponse> { }

public sealed record LoadArticleResponse();
