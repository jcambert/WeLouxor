using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadArticleQuery))]
public class LoadArticleQuery : ILoadArticleQuery
{
    public string Filename { get; set; }
}
