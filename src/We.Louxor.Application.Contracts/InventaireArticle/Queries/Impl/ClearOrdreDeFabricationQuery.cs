namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IClearOrdreDeFabricationQuery))]
public class ClearOrdreDeFabricationQuery
    : ClearBaseQuery<ClearOrdreDeFabricationResponse>,
      IClearOrdreDeFabricationQuery { }
