using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class LoadArticleHandler : BaseHandler<LoadArticleQuery, LoadArticleResponse>
{
    public LoadArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<LoadArticleResponse> Handle(LoadArticleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
