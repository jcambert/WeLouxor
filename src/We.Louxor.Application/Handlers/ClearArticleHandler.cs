using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class ClearArticleHandler
    : ClearBaseHandler<ClearArticleQuery, ClearArticleResponse, Article, ArticleDto>
{
    public ClearArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override ClearArticleResponse GetResponse() => new ClearArticleResponse();
}
