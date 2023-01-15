using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class GetArticleHandler : BaseHandler<GetArticleQuery, GetArticleResponse>
{
    public GetArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override Task<GetArticleResponse> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
