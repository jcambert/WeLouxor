using We.Louxor.InventaireArticle;
using We.Louxor.InventaireArticle.Queries;
using We.Results;

namespace We.Louxor.Handlers;

public class GetArticleHandler : BaseHandler<GetArticleQuery, GetArticleResponse>
{
    protected IRepository<Article, Guid> repository =>
        LazyServiceProvider.GetRequiredService<IRepository<Article, Guid>>();

    public GetArticleHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider) { }

    protected override async Task<Result<GetArticleResponse>> InternalHandle(GetArticleQuery request, CancellationToken cancellationToken)
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
