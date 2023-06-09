namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IBrowseArticleQuery))]
public class BrowseArticleQuery : IBrowseArticleQuery
{
    public string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
}
