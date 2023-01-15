using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;

[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(IGetArticleQuery))]
public class GetArticleQuery : IGetArticleQuery
{
    public string Code { get; set; }
    public string Designation { get; set; }
}
