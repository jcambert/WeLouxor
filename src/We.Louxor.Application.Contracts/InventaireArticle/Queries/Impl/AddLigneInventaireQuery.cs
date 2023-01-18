namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IAddLigneInventaireQuery))]
public class AddLigneInventaireQuery : IAddLigneInventaireQuery
{
    public BaseLigneInventaire Ligne { get; set; }
}
