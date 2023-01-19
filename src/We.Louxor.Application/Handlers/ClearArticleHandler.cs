using System;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class ClearArticleHandler : ClearBaseHandler<ClearArticleQuery, ClearArticleResponse, Article, Guid>
{
    public ClearArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }


}
