using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class BrowseArticleHandler : BaseHandler<BrowseArticleQuery, BrowseArticleResponse>
{
    protected IRepository<Article, Guid> repository =>
        LazyServiceProvider.GetRequiredService<IRepository<Article, Guid>>();

    public BrowseArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override async Task<Result<BrowseArticleResponse>> InternalHandle(
        BrowseArticleQuery request,
        CancellationToken cancellationToken
    )
    {
        var query = await repository.GetQueryableAsync();
        query = from q in query where q.Societe == request.Societe orderby q.Code  select q;

        var res = await AsyncExecuter.ToListAsync(query, cancellationToken);

        List<string> ress = new();
        ress.AddRange(res.Select(x => x.Code));
        return new BrowseArticleResponse(ress);
    }
}
