using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using We.Louxor.Data;
using Volo.Abp.DependencyInjection;

namespace We.Louxor.EntityFrameworkCore;

public class EntityFrameworkCoreLouxorDbSchemaMigrator
    : ILouxorDbSchemaMigrator,
      ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLouxorDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LouxorDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider.GetRequiredService<LouxorDbContext>().Database.MigrateAsync();
    }
}
