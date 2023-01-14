using Volo.Abp.Modularity;

namespace We.Louxor;

[DependsOn(
    typeof(LouxorApplicationModule),
    typeof(LouxorDomainTestModule)
    )]
public class LouxorApplicationTestModule : AbpModule
{

}
