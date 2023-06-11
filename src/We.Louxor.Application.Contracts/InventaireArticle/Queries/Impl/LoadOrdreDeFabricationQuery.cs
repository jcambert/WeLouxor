namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadOrdreDeFabricationQuery))]
public class LoadOrdreDeFabricationQuery
    : LoadBaseQuery<LoadOrdreDeFabricationResponse>,
      ILoadOrdreDeFabricationQuery
{
    protected override string GetDefaultFilename() => @"ppchar.dbf";
}
