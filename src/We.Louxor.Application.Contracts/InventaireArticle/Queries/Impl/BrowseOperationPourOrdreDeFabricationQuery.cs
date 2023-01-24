namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IBrowseOperationPourOrdreDeFabricationQuery))]
public class BrowseOperationPourOrdreDeFabricationQuery : IBrowseOperationPourOrdreDeFabricationQuery
{
    public string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
    public string OrdreDeFabrication { get; set; }
}
