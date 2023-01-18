using System;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadArticleHandler : BaseLoadHandler<LoadArticleQuery, LoadArticleResponse, Article, Guid>
{
    public LoadArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected override LoadArticleResponse GetResponse()
    => new();
}
/*
public class LoadArticleHandler : BaseHandler<LoadArticleQuery, LoadArticleResponse>
{
    public LoadArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<LoadArticleResponse> Handle(LoadArticleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}*/
