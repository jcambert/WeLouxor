using We.Louxor.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace We.Louxor.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LouxorEntityFrameworkCoreModule),
    typeof(LouxorApplicationContractsModule)
    )]
public class LouxorDbMigratorModule : AbpModule
{

}
