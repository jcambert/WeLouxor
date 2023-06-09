namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IClearArticleQuery))]
public class ClearArticleQuery : ClearBaseQuery, IClearArticleQuery { }
