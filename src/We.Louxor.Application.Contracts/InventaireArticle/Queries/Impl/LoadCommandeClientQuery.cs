namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadCommandeClientQuery))]
public class LoadCommandeClientQuery : LoadBaseQuery<LoadCommandeClientResponse>, ILoadCommandeClientQuery
{
    protected override string GetDefaultFilename() => @"cmlign.dbf";
}
