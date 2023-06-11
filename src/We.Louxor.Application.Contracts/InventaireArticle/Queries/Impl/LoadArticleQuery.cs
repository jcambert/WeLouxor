namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadArticleQuery))]
public class LoadArticleQuery : LoadBaseQuery<LoadArticleResponse>, ILoadArticleQuery
{
    protected override string GetDefaultFilename() => @"pparti.dbf";
}
