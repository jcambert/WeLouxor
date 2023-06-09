using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;

namespace We.Louxor.Handlers;

public class GetArticleHandler : BaseHandler<GetArticleQuery, GetArticleResponse>
{
    protected IRepository<Article, Guid> repository =>
        LazyServiceProvider.GetRequiredService<IRepository<Article, Guid>>();

    public GetArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }

    public override async Task<GetArticleResponse> Handle(
        GetArticleQuery request,
        CancellationToken cancellationToken
    )
    {
        var query = await repository.GetQueryableAsync();
        query =
            from q in query
            where q.Societe == request.Societe && q.Code == request.Code
            select q;
        var res = await AsyncExecuter.FirstOrDefaultAsync(query, cancellationToken);
        return new GetArticleResponse(res);
    }
}
