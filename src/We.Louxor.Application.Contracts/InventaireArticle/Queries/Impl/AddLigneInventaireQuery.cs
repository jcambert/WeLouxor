using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IAddLigneInventaireQuery))]
public class AddLigneInventaireQuery : IAddLigneInventaireQuery
{
    public ILigneInventaire Ligne { get; set; }
}
