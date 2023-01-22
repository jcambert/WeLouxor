namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IBrowseOrdreDeFabricationQuery))]
public class BrowseOrdreDeFabricationQuery : IBrowseOrdreDeFabricationQuery
{
    public string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
}
