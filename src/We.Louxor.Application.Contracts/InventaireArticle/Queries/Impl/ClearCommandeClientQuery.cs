namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IClearCommandeClientQuery))]
public class ClearCommandeClientQuery:ClearBaseQuery, IClearCommandeClientQuery
{
}
