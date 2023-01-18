using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadCommandeClientQuery))]
public class LoadCommandeClientQuery : ILoadCommandeClientQuery
{
    public string Filename { get; set; } = @"cmlign.dbf";

    public int? LimitRecordCountTo { get; set; } = null;

    public int LoadRecordStep { get; set; } = 100;
}
