namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IGetArticleQuery))]
public class GetArticleQuery : IGetArticleQuery
{
    public string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
    public string Code { get; set; }
    public string Designation { get; set; }
}
