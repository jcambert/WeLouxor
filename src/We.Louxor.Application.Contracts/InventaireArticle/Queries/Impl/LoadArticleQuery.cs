using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadArticleQuery))]
public class LoadArticleQuery : ILoadArticleQuery
{
    public string Filename { get; set; }=@"pparti.dbf";
    public int From { get; set; } = 0;
    public int? To { get; set; } = null;
    public int LoadRecordStep { get; set; } = 100;
    public bool TestForDuplicate { get; set; } = false;
}
