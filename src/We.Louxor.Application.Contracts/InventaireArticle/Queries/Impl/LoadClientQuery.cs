namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadClientQuery))]
public class LoadClientQuery : LoadBaseQuery<LoadClientResponse>, ILoadClientQuery
{
    protected override string GetDefaultFilename() => @"ptfour.dbf";
}
