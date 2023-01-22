using System;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IGetLigneInventaireQuery))]
public class GetLigneInventaireQuery : IGetLigneInventaireQuery
{
    public Guid Id { get; set; }
}
