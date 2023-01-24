namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IBrowseLigneInventaireQuery))]
public class BrowseLigneInventaireQuery : IBrowseLigneInventaireQuery
{
    public string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
}
