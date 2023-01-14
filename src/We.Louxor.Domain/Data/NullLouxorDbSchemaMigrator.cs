using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.Data;

/* This is used if database provider does't define
 * ILouxorDbSchemaMigrator implementation.
 */
public class NullLouxorDbSchemaMigrator : ILouxorDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
