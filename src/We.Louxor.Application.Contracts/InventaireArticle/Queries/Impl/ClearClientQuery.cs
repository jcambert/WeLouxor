namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IClearClientQuery))]
public class ClearClientQuery : ClearBaseQuery, IClearClientQuery { }
