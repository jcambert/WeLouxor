using System.Collections.Generic;

namespace We.Louxor.InventaireArticle.Queries;

public interface IBrowseArticleQuery:IInventaireQuery<BrowseArticleResponse>,ISociete
{
}

public sealed record BrowseArticleResponse(List<string> Articles):InventaireResponse;
