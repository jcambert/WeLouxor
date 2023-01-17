namespace We.Louxor.InventaireArticle.Queries;

public interface ILoadArticleQuery:IInventaireQuery<LoadArticleResponse>
{
    string Filename { get; set; }
}

public sealed record LoadArticleResponse();