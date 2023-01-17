using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadCommandeClientQuery))]
public class LoadCommandeClientQuery : ILoadCommandeClientQuery
{
    public string Filename { get; set; } = @"E:\projets\WeLouxor\Database\cmlign.dbf";
}
