using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadOrdreDeFabricationQuery))]
public class LoadOrdreDeFabricationQuery : ILoadOrdreDeFabricationQuery
{
    public string Filename { get; set; }
    public int? LimitRecordCountTo { get; set; }
    public int LoadRecordStep { get; set; }
}
