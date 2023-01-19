using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadOrdreDeFabricationQuery))]
public class LoadOrdreDeFabricationQuery : ILoadOrdreDeFabricationQuery
{
    public string Filename { get; set; }=@"ppchar.dbf";
    public int From { get; set; } = 0;
    public int? To { get; set; } = null;
    public int LoadRecordStep { get; set; } = 100;
    public bool TestForDuplicate { get; set; } = false;
}
