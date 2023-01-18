namespace We.Louxor.InventaireArticle.Queries;

public interface IClearArticleQuery : IClearBaseQuery, IInventaireQuery<ClearArticleResponse>
{

}
public sealed record ClearArticleResponse();