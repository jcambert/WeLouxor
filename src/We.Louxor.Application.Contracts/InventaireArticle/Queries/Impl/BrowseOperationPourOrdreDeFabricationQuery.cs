namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IBrowseOperationPourOrdreDeFabricationQuery))]
public class BrowseOperationPourOrdreDeFabricationQuery : IBrowseOperationPourOrdreDeFabricationQuery
{
    public string Societe { get; set; } = LouxorAppConsts.LouxorDefaultSociete;
    public int OrdreDeFabrication { get; set; }
}
