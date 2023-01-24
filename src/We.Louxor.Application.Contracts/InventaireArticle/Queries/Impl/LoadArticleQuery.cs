using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.InventaireArticle.Queries;
[Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
[ExposeServices(typeof(ILoadArticleQuery))]
public class LoadArticleQuery :LoadBaseQuery, ILoadArticleQuery { 


    protected override string GetDefaultFilename()
    =>@"pparti.dbf";
}
